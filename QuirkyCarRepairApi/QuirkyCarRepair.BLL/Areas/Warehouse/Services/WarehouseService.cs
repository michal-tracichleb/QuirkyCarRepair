using AutoMapper;
using QuirkyCarRepair.BLL.Areas.Identity.Interfaces;
using QuirkyCarRepair.BLL.Areas.Shared;
using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;
using QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.BLL.Extensions;
using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.Shared.Enums;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;
using QuirkyCarRepair.DAL.Exceptions;

namespace QuirkyCarRepair.BLL.Areas.Warehouse.Services
{
    internal class WarehouseService : IWarehouseService
    {
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;

        private readonly IPartCategoryRepository _partCategoryRepository;
        private readonly IPartRepository _partRepository;
        private readonly ITransactionStatusRepository _transactionStatusRepository;
        private readonly IOperationalDocumentRepository _operationalDocumentRepository;
        private readonly IPartTransactionRepository _partTransactionRepository;
        private readonly IServiceOrderRepository _serviceOrderRepository;

        public WarehouseService(IMapper mapper,
            IUserContextService userContextService,
            IPartCategoryRepository partCategoryRepository,
            IPartRepository partRepository,
            ITransactionStatusRepository transactionStatusRepository,
            IOperationalDocumentRepository operationalDocumentRepository,
            IPartTransactionRepository partTransactionRepository,
            IServiceOrderRepository serviceOrderRepository)
        {
            _mapper = mapper;
            _userContextService = userContextService;

            _partCategoryRepository = partCategoryRepository;
            _partRepository = partRepository;
            _transactionStatusRepository = transactionStatusRepository;
            _operationalDocumentRepository = operationalDocumentRepository;
            _partTransactionRepository = partTransactionRepository;
            _serviceOrderRepository = serviceOrderRepository;
        }

        public List<PartCategoryEntity> GetPrimaryCategories()
        {
            return _mapper.Map<List<PartCategoryEntity>>(_partCategoryRepository.GetPrimaryCategories());
        }

        public PartCategoryStructureDTO GetPartCategoryStructure(int id)
        {
            if (_partCategoryRepository.Exist(id) == false)
                throw new NotFoundException("Part category connot found");

            PartCategory partCategory = _partCategoryRepository.GetWithInclude(id);
            PartCategoryStructureDTO partCategoryStructure = _mapper.Map<PartCategoryStructureDTO>(partCategory);

            if (partCategory.ParentCategoryId != null && partCategory.ParentCategoryId != 0)
            {
                if (_partCategoryRepository.Exist((int)partCategory.ParentCategoryId) == false)
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
            if (_partCategoryRepository.Exist(getPartsPageDTO.CategoryId) == false)
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

        public void DeliveryParts(List<PartDTO> deliveryPartsDTO)
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
                Type = OrderType.D.ToString(),
                PartTransactions = partsTransactions
            };

            TransactionStatus status = new TransactionStatus()
            {
                OperationalDocument = operationalDocument,
                StartDate = DateTime.Now,
                Status = OrderStatus.Ready.ToString(),
                UserId = _userContextService.GetUserId
            };

            _partRepository.UpdateRange(parts);
            _transactionStatusRepository.Add(status);

            AssignOperationalDocumentNumber(operationalDocument);
        }

        public void OrderParts(OrderDTO orderDTO)
        {
            // TODO: walidacja pod względem niewystarczającej ilości części, lepsza implementacja

            if (orderDTO.OrderParts.Any() == false)
                throw new QuantityOutOfRangeException("OrderParts cannot be equal to 0");

            OrderType transactionType;
            if (orderDTO.OrderType.Equals("WW") && orderDTO.ServiceOrderId != 0)
            {
                if (_serviceOrderRepository.Exist(orderDTO.ServiceOrderId) == false)
                    throw new NotFoundException("Service order Id connot found");

                transactionType = OrderType.WW;
            }
            else if (orderDTO.OrderType.Equals("WZ") && orderDTO.ServiceOrderId == 0)
            {
                transactionType = OrderType.WZ;
            }
            else
            {
                throw new NotFoundException("Transaction type connot found");
            }

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
                PartTransactions = partsTransactions,
                ServiceOrderId = orderDTO.ServiceOrderId == 0 ? null : orderDTO.ServiceOrderId,
            };

            TransactionStatus status = new TransactionStatus()
            {
                OperationalDocument = operationalDocument,
                StartDate = DateTime.Now,
                Status = OrderStatus.Pending.ToString(),
                UserId = _userContextService.GetUserId
            };

            _partRepository.UpdateRange(parts);
            _transactionStatusRepository.Add(status);

            AssignOperationalDocumentNumber(operationalDocument);
        }

        public PageList<OperationalDocumentDTO> GetOrdersPage(GetOrdersPageDTO getOrdersPageDTO)
        {
            var orders = _operationalDocumentRepository.GetOperationalDocumentsWithLatestTransactionStatus(
                getOrdersPageDTO.OrderTypes, getOrdersPageDTO.OrderStates);

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

        public void CancelOrder(int id)
        {
            if (_operationalDocumentRepository.Exist(id) == false)
                throw new NotFoundException("Operational document connot found");

            if (CheckStatus(id, OrderStatus.Pending) == false)
                throw new NotFoundException("Status is other than pending");

            var partsTransactions = _partTransactionRepository.GetByOperationalDocument(id);
            List<Part> parts = new List<Part>();

            foreach (var partTransaction in partsTransactions)
            {
                var part = _partRepository.Get(partTransaction.PartId);
                part.Quantity += partTransaction.Quantity;
                parts.Add(part);
            }

            TransactionStatus status = new TransactionStatus()
            {
                OperationalDocumentid = id,
                StartDate = DateTime.Now,
                Status = OrderStatus.Canceled.ToString(),
                UserId = _userContextService.GetUserId
            };

            _partRepository.UpdateRange(parts);
            _transactionStatusRepository.Add(status);
        }

        public DetailsOrderDTO DetailsOrder(int id)
        {
            var operationalDocument = _operationalDocumentRepository.Get(id);
            var latestTransactionStatus = _transactionStatusRepository.GetLatestStatus(id);
            var partsTransactions = _partTransactionRepository.GetByOperationalDocument(id);

            var result = new DetailsOrderDTO()
            {
                OperationalDocumentId = id,
                DocumentNumber = operationalDocument.DocumentNumber,
                TransactionStartDate = operationalDocument.TransactionDate,
                Type = operationalDocument.Type,
                StatusStartDate = latestTransactionStatus.StartDate,
                Status = latestTransactionStatus.Status,
                Description = latestTransactionStatus.Description,
                OrderedParts = new List<OrderedPartDTO>()
            };

            foreach (var partTransaction in partsTransactions)
            {
                var part = _partRepository.Get(partTransaction.PartId);

                result.OrderedParts.Add(
                    new OrderedPartDTO()
                    {
                        PartId = partTransaction.PartId,
                        Name = part.Name,
                        Quantity = partTransaction.Quantity,
                        UnitType = part.UnitType,
                        UnitPrice = partTransaction.UnitPrice,
                        MarginValue = partTransaction.MarginValue,
                    });
            }

            return result;
        }

        public DetailsOrderDTO ArrangeOrder(int id)
        {
            if (_operationalDocumentRepository.Exist(id) == false)
                throw new NotFoundException("Operational document connot found");

            if (CheckStatus(id, OrderStatus.Pending) == false)
                throw new NotFoundException("Status is other than pending");

            TransactionStatus status = new TransactionStatus()
            {
                OperationalDocumentid = id,
                StartDate = DateTime.Now,
                Status = OrderStatus.ArrangeOrder.ToString(),
                UserId = _userContextService.GetUserId
            };

            _transactionStatusRepository.Add(status);

            return DetailsOrder(id);
        }

        public DetailsOrderDTO ReadyForPickup(int id)
        {
            if (_operationalDocumentRepository.Exist(id) == false)
                throw new NotFoundException("Operational document connot found");

            if (CheckStatus(id, OrderStatus.ArrangeOrder) == false)
                throw new NotFoundException("Status is other than arrange order");

            TransactionStatus status = new TransactionStatus()
            {
                OperationalDocumentid = id,
                StartDate = DateTime.Now,
                Status = OrderStatus.ReadyForPickup.ToString(),
                UserId = _userContextService.GetUserId
            };

            _transactionStatusRepository.Add(status);

            return DetailsOrder(id);
        }

        public DetailsOrderDTO OrderCompleted(int id)
        {
            if (_operationalDocumentRepository.Exist(id) == false)
                throw new NotFoundException("Operational document connot found");

            if (CheckStatus(id, OrderStatus.ReadyForPickup) == false)
                throw new NotFoundException("Status is other than ready for pickup");

            TransactionStatus status = new TransactionStatus()
            {
                OperationalDocumentid = id,
                StartDate = DateTime.Now,
                Status = OrderStatus.OrderCompleted.ToString(),
                UserId = _userContextService.GetUserId
            };

            _transactionStatusRepository.Add(status);

            return DetailsOrder(id);
        }

        private void AssignOperationalDocumentNumber(OperationalDocument document)
        {
            var prefix = document.Type;
            var date = $"{document.TransactionDate.Year}-{document.TransactionDate.Month.ToString($"D2")}-{document.TransactionDate.Day.ToString($"D2")}";
            var number = document.Id.ToString($"D9");

            document.DocumentNumber = $"{prefix}/{date}/{number}";
            _operationalDocumentRepository.Update(document);
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

        private bool CheckStatus(int operationalDocumentId, OrderStatus expectedStatus)
        {
            var transactionStatus = _transactionStatusRepository.GetLatestStatus(operationalDocumentId);
            if (transactionStatus.Status == expectedStatus.ToString())
                return true;

            return false;
        }
    }
}