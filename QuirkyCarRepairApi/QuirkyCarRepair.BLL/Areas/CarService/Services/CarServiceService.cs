using AutoMapper;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuirkyCarRepair.BLL.Areas.CarService.DTO;
using QuirkyCarRepair.BLL.Areas.CarService.Entities;
using QuirkyCarRepair.BLL.Areas.CarService.Interfaces;
using QuirkyCarRepair.BLL.Areas.Identity.Interfaces;
using QuirkyCarRepair.BLL.Areas.InvoiceGenerator.Services;
using QuirkyCarRepair.BLL.Areas.Shared;
using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;
using QuirkyCarRepair.BLL.Extensions;
using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Identity.Interfaces;
using QuirkyCarRepair.DAL.Areas.Shared.Enums;
using QuirkyCarRepair.DAL.Areas.Shared.Interfaces;
using QuirkyCarRepair.DAL.Areas.Shared.Models;
using QuirkyCarRepair.DAL.Exceptions;
using System.Text;

namespace QuirkyCarRepair.BLL.Areas.CarService.Services
{
    internal class CarServiceService : ICarServiceService
    {
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;

        private readonly IAccountRepostiory _accountRepostiory;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IServiceOrderRepository _serviceOrderRepository;
        private readonly IOrderOwnerRepository _orderOwnerRepository;
        private readonly IServiceOrderStatusRepository _serviceOrderStatusRepository;
        private readonly IMainCategoryServiceRepository _mainCategoryServiceRepository;
        private readonly IServiceOfferRepository _serviceOfferRepository;
        private readonly IServiceTransactionRepository _serviceTransactionRepository;

        public CarServiceService(IMapper mapper,
            IUserContextService userContextService,
            IAccountRepostiory accountRepostiory,
            IVehicleRepository vehicleRepository,
            IServiceOrderRepository serviceOrderRepository,
            IOrderOwnerRepository orderOwnerRepository,
            IServiceOrderStatusRepository serviceOrderStatusRepository,
            IMainCategoryServiceRepository mainCategoryServiceRepository,
            IServiceOfferRepository serviceOfferRepository,
            IServiceTransactionRepository serviceTransactionRepository)
        {
            _mapper = mapper;
            _userContextService = userContextService;

            _accountRepostiory = accountRepostiory;
            _vehicleRepository = vehicleRepository;
            _serviceOrderRepository = serviceOrderRepository;
            _orderOwnerRepository = orderOwnerRepository;
            _serviceOrderStatusRepository = serviceOrderStatusRepository;
            _mainCategoryServiceRepository = mainCategoryServiceRepository;
            _serviceOfferRepository = serviceOfferRepository;
            _serviceTransactionRepository = serviceTransactionRepository;
        }

        public DetailsServiceOrderDTO NewOrderService(CreateServiceOrderDTO createServiceOrder)
        {
            if (createServiceOrder.UserId != 0
                && _accountRepostiory.Exist(createServiceOrder.UserId) == false)
                throw new NotFoundException("User cannot found");

            if (createServiceOrder.VehicleId != 0
                && _vehicleRepository.Exist(createServiceOrder.VehicleId) == false)
                throw new NotFoundException("Vehicle cannot found");

            var newServiceOrderStatus = new ServiceOrderStatus()
            {
                UserId = _userContextService.GetUserId,
                StartDate = DateTime.Now,
                Status = OrderStatus.Pending.ToString(),
                Description = createServiceOrder.OrderDescription
            };

            var newOrderOwner = new OrderOwner()
            {
                UserId = _userContextService.GetRoleName != "User" ? null : _userContextService.GetUserId,
                FirstName = createServiceOrder.FirstName,
                LastName = createServiceOrder.LastName,
                PhoneNumber = createServiceOrder.PhoneNumber
            };

            var newServiceOrder = new ServiceOrder()
            {
                OrderNumber = $"{OrderType.ZS.ToString()}/{newServiceOrderStatus.StartDate.Year}-{newServiceOrderStatus.StartDate.Month.ToString($"D2")}-{newServiceOrderStatus.StartDate.Month.ToString($"D2")}/",
                DateStartRepair = createServiceOrder.DateStartRepair,
                OrderOwner = newOrderOwner,
                OrderDescription = createServiceOrder.OrderDescription,
                ServiceOrderStatuses = new List<ServiceOrderStatus>() { newServiceOrderStatus }
            };

            if (createServiceOrder.VehicleId == 0)
            {
                newServiceOrder.Vehicle = new Vehicle()
                {
                    UserId = createServiceOrder.UserId == 0 ? null : createServiceOrder.UserId,
                    VIN = createServiceOrder.Vin,
                    PlateNumber = createServiceOrder.PlateNumber,
                    Model = createServiceOrder.Model,
                    Brand = createServiceOrder.Brand,
                    Year = createServiceOrder.Year
                };
            }
            else
            {
                newServiceOrder.VehicleId = createServiceOrder.VehicleId;
            }

            _serviceOrderRepository.Add(newServiceOrder);

            var builder = new StringBuilder();
            builder.Append(newServiceOrder.OrderNumber);
            builder.Append(newServiceOrder.Id.ToString($"D9"));

            newServiceOrder.OrderNumber = builder.ToString();

            _serviceOrderRepository.Update(newServiceOrder);
            var vehicleRepository = _vehicleRepository.Get(newServiceOrder.VehicleId);

            newServiceOrder.Vehicle = vehicleRepository;

            return _mapper.Map<DetailsServiceOrderDTO>(newServiceOrder);
        }

        public PageList<ServiceOrderDTO> GetOrdersPage(GetServiceOrderPage getOrdersServicePageDTO)
        {
            IQueryable<ServiceOrder> orders;
            if (_userContextService.GetRoleName != "User")
            {
                orders = _serviceOrderRepository.GetServicesOrdersWithLatestStatus(getOrdersServicePageDTO.OrderStates,
                    getOrdersServicePageDTO.AnyDate, getOrdersServicePageDTO.FromDate, getOrdersServicePageDTO.ToDate);
            }
            else
            {
                orders = _serviceOrderRepository.GetServicesOrdersWithLatestStatusByOwner(_userContextService.GetUserId, getOrdersServicePageDTO.OrderStates,
                    getOrdersServicePageDTO.AnyDate, getOrdersServicePageDTO.FromDate, getOrdersServicePageDTO.ToDate);
            }

            PageList<ServiceOrder> ordersPageList = orders.GetPagedList<ServiceOrder>(getOrdersServicePageDTO.Page, getOrdersServicePageDTO.PageSize);

            var result = new PageList<ServiceOrderDTO>()
            {
                CurrentPage = ordersPageList.CurrentPage,
                PageCount = ordersPageList.PageCount,
                PageSize = ordersPageList.PageSize,
                ItemCount = ordersPageList.ItemCount,
                Items = _mapper.Map<List<ServiceOrderDTO>>(ordersPageList.Items)
            };

            return result;
        }

        public DetailsServiceOrderDTO GetDetailsServiceOrder(int id)
        {
            var serviceOrder = _serviceOrderRepository.GetWithInclude(id);
            if (serviceOrder == null)
                throw new NotFoundException("Service order cannot found");

            //if (_userContextService.GetRoleName == "User" && serviceOrder.OrderOwner.UserId != _userContextService.GetUserId)
            //    throw new BadRequestException("You don't have permission to see that");

            var result = _mapper.Map<DetailsServiceOrderDTO>(serviceOrder);

            var partsTransaction = serviceOrder.OperationalDocuments.SelectMany(x => x.PartTransactions).ToList();
            result.Parts = _mapper.Map<List<PartDTO>>(partsTransaction);

            return result;
        }

        public List<MainCategoryServiceEntity> GetAllMainCategoryService()
        {
            return _mapper.Map<List<MainCategoryServiceEntity>>(_mainCategoryServiceRepository.GetAll());
        }

        public List<ServiceOfferEntity> GetServiceOfferByMainCategory(int mainCategoryId)
        {
            return _mapper.Map<List<ServiceOfferEntity>>(_serviceOfferRepository.GetByMainCategoryId(mainCategoryId));
        }

        public List<ServiceOfferEntity> GetAllServiceOffer()
        {
            return _mapper.Map<List<ServiceOfferEntity>>(_serviceOfferRepository.GetAll());
        }

        public DetailsServiceOrderDTO ChangeStatus(int id, string? description, OrderStatus newStatus)
        {
            if (_serviceOrderRepository.Exist(id) == false)
                throw new NotFoundException("Service order cannot found");

            CheckStatusNewStatus(id, newStatus);

            _serviceOrderStatusRepository.Add(new ServiceOrderStatus()
            {
                UserId = _userContextService.GetUserId,
                ServiceOrderId = id,
                StartDate = DateTime.Now,
                Description = description,
                Status = newStatus.ToString()
            });

            return GetDetailsServiceOrder(id);
        }

        public DetailsServiceOrderDTO AddServiceToOrder(int serviceOrderId, int serviceOfferId, int numberOfServices)
        {
            if (_serviceOrderRepository.Exist(serviceOrderId) == false)
                throw new NotFoundException("Service order cannot found");

            if (_serviceOfferRepository.Exist(serviceOfferId) == false)
                throw new NotFoundException("Service offer cannot found");

            if (numberOfServices <= 0)
                throw new QuantityOutOfRangeException("Number of services cannot be below or equal 0");

            var newServiceTransaction = new ServiceTransaction()
            {
                ServiceOfferId = serviceOfferId,
                ServiceOrderId = serviceOrderId,
                Quantity = numberOfServices,
                Price = _serviceOfferRepository.Get(serviceOfferId).Price,
                MarginValue = 0, //TODO
            };

            _serviceTransactionRepository.Add(newServiceTransaction);

            return GetDetailsServiceOrder(serviceOrderId);
        }

        public void GetInvoicePDF(int serviceOrderId)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var dir = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(dir, $"InvoicPDF/invoice{serviceOrderId}.pdf");

            var model = InvoiceDocumentDataSource.GetInvoiceDetails(GetDetailsServiceOrder(serviceOrderId));
            var document = new InvoiceDocument(model);
            document.GeneratePdf(filePath);
        }

        private void CheckStatusNewStatus(int serviceOrderId, OrderStatus newStatus)
        {
            var latestStatus = _serviceOrderStatusRepository.GetLatestStatus(serviceOrderId);

            switch (newStatus)
            {
                case OrderStatus.Canceled:
                    if (latestStatus.Status != OrderStatus.Pending.ToString())
                        throw new NotFoundException("Status is other than Pending");
                    break;

                case OrderStatus.AcceptedDate:
                    if (latestStatus.Status != OrderStatus.Pending.ToString())
                        throw new NotFoundException("Status is other than Pending");
                    break;

                case OrderStatus.RepairAnalysis:
                    if (latestStatus.Status != OrderStatus.AcceptedDate.ToString())
                        throw new NotFoundException("Status is other than AcceptedDate");
                    break;

                case OrderStatus.PendingForClientAccepting:
                    if (latestStatus.Status != OrderStatus.RepairAnalysis.ToString())
                        throw new NotFoundException("Status is other than RepairAnalysis");
                    break;

                case OrderStatus.AcceptedByClient:
                    if (latestStatus.Status != OrderStatus.PendingForClientAccepting.ToString())
                        throw new NotFoundException("Status is other than PendingForClientAccepting");
                    break;

                case OrderStatus.CanceledByclient:
                    if (latestStatus.Status != OrderStatus.PendingForClientAccepting.ToString())
                        throw new NotFoundException("Status is other than PendingForClientAccepting");
                    break;

                case OrderStatus.Repair:
                    if (latestStatus.Status != OrderStatus.AcceptedByClient.ToString()
                        && latestStatus.Status != OrderStatus.Complaint.ToString())
                        throw new NotFoundException("Status is other than AcceptedByClient or Complaint");
                    break;

                case OrderStatus.Ready:
                    if (latestStatus.Status != OrderStatus.Repair.ToString())
                        throw new NotFoundException("Status is other than Repair");
                    break;

                case OrderStatus.Complaint:
                    if (latestStatus.Status != OrderStatus.Ready.ToString())
                        throw new NotFoundException("Status is other than Ready");
                    break;

                default:
                    if (latestStatus.Status != OrderStatus.Pending.ToString())
                        throw new NotFoundException("Status is other than expected");
                    break;
            }
        }
    }
}