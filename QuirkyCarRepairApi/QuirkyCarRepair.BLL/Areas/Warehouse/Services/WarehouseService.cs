using AutoMapper;
using QuirkyCarRepair.BLL.Areas.Shared;
using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;
using QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.BLL.Extensions;
using QuirkyCarRepair.DAL.Areas.Shared.Enums;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;
using QuirkyCarRepair.DAL.Exceptions;

namespace QuirkyCarRepair.BLL.Areas.Warehouse.Services
{
    internal class WarehouseService : IWarehouseService
    {
        private readonly IMapper _mapper;
        private readonly IPartCategoryRepository _partCategoryRepository;
        private readonly IPartRepository _partRepository;
        private readonly ITransactionStatusRepository _transactionStatusRepository;
        private readonly IOperationalDocumentRepository _operationalDocumentRepository;

        public WarehouseService(IMapper mapper,
            IPartCategoryRepository partCategoryRepository,
            IPartRepository partRepository,
            ITransactionStatusRepository transactionStatusRepository,
            IOperationalDocumentRepository operationalDocumentRepository)
        {
            _mapper = mapper;
            _partCategoryRepository = partCategoryRepository;
            _partRepository = partRepository;
            _transactionStatusRepository = transactionStatusRepository;
            _operationalDocumentRepository = operationalDocumentRepository;
        }

        public List<PartCategoryEntity> GetPrimaryCategories()
        {
            return _mapper.Map<List<PartCategoryEntity>>(_partCategoryRepository.GetPrimaryCategories());
        }

        public PartCategoryStructureDTO GetPartCategoryStructure(int id)
        {
            if (!_partCategoryRepository.Exist(id))
                throw new NotFoundException("Part category connot found");

            PartCategory partCategory = _partCategoryRepository.GetWithInclude(id);
            PartCategoryStructureDTO partCategoryStructure = _mapper.Map<PartCategoryStructureDTO>(partCategory);

            if (partCategory.ParentCategoryId != null && partCategory.ParentCategoryId != 0)
            {
                if (!_partCategoryRepository.Exist((int)partCategory.ParentCategoryId))
                    throw new NotFoundException("Parent for part category connot found");

                PartCategory parentPartCategory = _partCategoryRepository.GetWithInclude((int)partCategory.ParentCategoryId);
                partCategoryStructure.SiblingCategories = _mapper.Map<List<PartCategoryEntity>>(parentPartCategory.Subcategories);
            }
            else
            {
                partCategoryStructure.SiblingCategories = _mapper.Map<List<PartCategoryEntity>>(_partCategoryRepository.GetPrimaryCategories());
            }

            var categoryToRemove = partCategoryStructure.SiblingCategories.Find(x => x.Id == id);
            if (categoryToRemove != null)
                partCategoryStructure.SiblingCategories.Remove(categoryToRemove);

            return partCategoryStructure;
        }

        public PageList<PartEntity> GetPartsPage(GetPartsPageDTO getPartsPageDTO)
        {
            if (!_partCategoryRepository.Exist(getPartsPageDTO.CategoryId))
                throw new NotFoundException("Part category connot found");

            var categoryIds = ExtractCategoryIds(_partCategoryRepository.GetWithSubcategories(getPartsPageDTO.CategoryId));

            PageList<Part> partPageList = _partRepository.GetPartsByCategories(categoryIds, getPartsPageDTO.SortDirection,
                getPartsPageDTO.SearchPhrase, getPartsPageDTO.SortBy).GetPagedList<Part>(getPartsPageDTO.Page, getPartsPageDTO.PageSize);

            return new PageList<PartEntity>()
            {
                CurrentPage = partPageList.CurrentPage,
                PageCount = partPageList.PageCount,
                PageSize = partPageList.PageSize,
                ItemCount = partPageList.ItemCount,
                Items = _mapper.Map<List<PartEntity>>(partPageList.Items)
            };
        }

        private List<int> ExtractCategoryIds(PartCategory category)
        {
            var categoryIds = new List<int> { category.Id };

            if (category.Subcategories != null && category.Subcategories.Any())
            {
                foreach (var subcategory in category.Subcategories)
                {
                    categoryIds.AddRange(ExtractCategoryIds(subcategory));
                }
            }

            return categoryIds;
        }

        public void DeliveryParts(List<DeliveryPartsDTO> deliveryPartsDTO)
        {
            foreach (var deliveryParts in deliveryPartsDTO)
            {
                if (_partRepository.Exist(deliveryParts.Id) == false)
                    throw new NotFoundException("Part connot found");
            }

            List<Part> parts = new List<Part>();
            List<PartTransaction> partsTransactions = new List<PartTransaction>();

            foreach (var deliveryParts in deliveryPartsDTO)
            {
                var part = _partRepository.Get(deliveryParts.Id);
                part.Quantity += deliveryParts.Quantity;
                parts.Add(part);

                partsTransactions.Add(new PartTransaction()
                {
                    PartId = deliveryParts.Id,
                    Quantity = deliveryParts.Quantity,
                    UnitPrice = deliveryParts.UnitPrice,
                    MarginValue = 0,
                });
            }

            OperationalDocument operationalDocument = new OperationalDocument()
            {
                DocumentNumber = "XYZ",
                TransactionDate = DateTime.Now,
                Type = TransactionType.D.ToString(),
                PartTransactions = partsTransactions
            };

            TransactionStatus status = new TransactionStatus()
            {
                OperationalDocument = operationalDocument,
                StartDate = DateTime.Now,
                Status = TransactionState.Ready.ToString()
            };

            _partRepository.UpdateRange(parts);
            _transactionStatusRepository.Add(status);
        }

        public void OrderParts(OrderDTO orderDTO)
        {
            // TODO: walidacja pod względem niewystarczającej ilości części, lepsza implementacja

            TransactionType transactionType;
            if (orderDTO.OrderType.Equals("WW"))
                transactionType = TransactionType.WW;
            else if (orderDTO.OrderType.Equals("WZ"))
                transactionType = TransactionType.WZ;
            else
                throw new NotFoundException("Transaction type connot found");

            foreach (var orderParts in orderDTO.OrderParts)
            {
                if (_partRepository.Exist(orderParts.Id) == false)
                    throw new NotFoundException("Part connot found");
            }

            List<Part> parts = new List<Part>();
            List<PartTransaction> partsTransactions = new List<PartTransaction>();

            foreach (var orderParts in orderDTO.OrderParts)
            {
                var part = _partRepository.Get(orderParts.Id);

                if (part.Quantity < orderParts.Quantity)
                    throw new QuantityOutOfRangeException($"Part Id: {orderParts.Id}, there are no {orderParts.Quantity} in stock quantity.");

                part.Quantity -= orderParts.Quantity;
                parts.Add(part);

                partsTransactions.Add(new PartTransaction()
                {
                    PartId = orderParts.Id,
                    Quantity = orderParts.Quantity,
                    UnitPrice = part.UnitPrice,
                    MarginValue = 0,
                });
            }

            OperationalDocument operationalDocument = new OperationalDocument()
            {
                DocumentNumber = "XYZ",
                TransactionDate = DateTime.Now,
                Type = transactionType.ToString(),
                PartTransactions = partsTransactions
            };

            TransactionStatus status = new TransactionStatus()
            {
                OperationalDocument = operationalDocument,
                StartDate = DateTime.Now,
                Status = TransactionState.Pending.ToString()
            };

            _partRepository.UpdateRange(parts);
            _transactionStatusRepository.Add(status);
        }

        public PageList<OperationalDocumentDTO> GetOrdersPage(GetOrdersPageDTO getOrdersPageDTO)
        {
            var orders = _operationalDocumentRepository.GetOperationalDocumentsWithLatestTransactionStatus(
                getOrdersPageDTO.TransactionTypes, getOrdersPageDTO.TransactionStates);

            PageList<OperationalDocument> ordersPageList = orders.GetPagedList<OperationalDocument>(getOrdersPageDTO.Page, getOrdersPageDTO.PageSize);

            var result = new PageList<OperationalDocumentDTO>()
            {
                CurrentPage = ordersPageList.CurrentPage,
                PageCount = ordersPageList.PageCount,
                PageSize = ordersPageList.PageSize,
                ItemCount = ordersPageList.ItemCount,
                Items = _mapper.Map<List<OperationalDocumentDTO>>(ordersPageList.Items)
            };

            return result;
        }
    }
}