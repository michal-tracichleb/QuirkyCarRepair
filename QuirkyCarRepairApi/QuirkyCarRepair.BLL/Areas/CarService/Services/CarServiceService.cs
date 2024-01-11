using AutoMapper;
using QuirkyCarRepair.BLL.Areas.CarService.DTO;
using QuirkyCarRepair.BLL.Areas.CarService.Entities;
using QuirkyCarRepair.BLL.Areas.CarService.Interfaces;
using QuirkyCarRepair.BLL.Areas.Identity.Interfaces;
using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;
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

        public CarServiceService(IMapper mapper,
            IUserContextService userContextService,
            IAccountRepostiory accountRepostiory,
            IVehicleRepository vehicleRepository,
            IServiceOrderRepository serviceOrderRepository,
            IOrderOwnerRepository orderOwnerRepository,
            IServiceOrderStatusRepository serviceOrderStatusRepository)
        {
            _mapper = mapper;
            _userContextService = userContextService;

            _accountRepostiory = accountRepostiory;
            _vehicleRepository = vehicleRepository;
            _serviceOrderRepository = serviceOrderRepository;
            _orderOwnerRepository = orderOwnerRepository;
            _serviceOrderStatusRepository = serviceOrderStatusRepository;
        }

        public DetailsServiceOrderDTO NewOrderService(CreateServiceOrderDTO createServiceOrder)
        {
            if (createServiceOrder.UserId != 0
                && _accountRepostiory.Exist(createServiceOrder.UserId) == false)
                throw new NotFoundException("User cannot found");

            if (createServiceOrder.VehicleId != 0
                && _vehicleRepository.Exist(createServiceOrder.VehicleId) == false)
                throw new NotFoundException("Vehicle cannot found");

            var vehicle = new Vehicle()
            {
                Id = createServiceOrder.VehicleId,
                UserId = createServiceOrder.UserId == 0 ? null : createServiceOrder.UserId,
                VIN = createServiceOrder.Vin,
                PlateNumber = createServiceOrder.PlateNumber,
                Model = createServiceOrder.Model,
                Brand = createServiceOrder.Brand,
                Year = createServiceOrder.Year
            };

            var newServiceOrderStatus = new ServiceOrderStatus()
            {
                UserId = _userContextService.GetUserId,
                StartDate = DateTime.Now,
                Status = TransactionState.Pending.ToString(),
                Description = createServiceOrder.OrderDescription
            };

            var newOrderOwner = new OrderOwner()
            {
                UserId = createServiceOrder.UserId == 0 ? null : createServiceOrder.UserId,
                FirstName = createServiceOrder.FirstName,
                LastName = createServiceOrder.LastName,
                PhoneNumber = createServiceOrder.PhoneNumber
            };

            var newServiceOrder = new ServiceOrder()
            {
                OrderNumber = $"ZS/{newServiceOrderStatus.StartDate.Year}-{newServiceOrderStatus.StartDate.Month.ToString($"D2")}-{newServiceOrderStatus.StartDate.Month.ToString($"D2")}/",
                DateStartRepair = createServiceOrder.DateStartRepair,
                Vehicle = vehicle,
                OrderOwner = newOrderOwner,
                ServiceOrderStatuses = new List<ServiceOrderStatus>() { newServiceOrderStatus }
            };

            _serviceOrderRepository.Add(newServiceOrder);

            var builder = new StringBuilder();
            builder.Append(newServiceOrder.OrderNumber);
            builder.Append(newServiceOrder.Id.ToString($"D9"));

            newServiceOrder.OrderNumber = builder.ToString();

            _serviceOrderRepository.Update(newServiceOrder);

            return new DetailsServiceOrderDTO()
            {
                ServiceOrderId = newServiceOrder.Id,
                DocumentNumber = newServiceOrder.OrderNumber,
                DateStartRepair = newServiceOrder.DateStartRepair,
                StatusStartDate = newServiceOrderStatus.StartDate,
                Status = newServiceOrderStatus.Status,
                OrderDescription = newServiceOrderStatus.Description,
                UserData = new UserDataDTO()
                {
                    FirstName = newOrderOwner.FirstName,
                    LastName = newOrderOwner.LastName,
                    PhoneNumber = newOrderOwner.PhoneNumber
                },
                VehicleData = new VehicleDataDTO()
                {
                    Vin = vehicle.VIN,
                    PlateNumber = vehicle.PlateNumber,
                    Brand = vehicle.Brand,
                    Model = vehicle.Model,
                    Year = vehicle.Year
                },
                ServiceOrderStatuses = new List<ServiceOrderStatusEntity> { _mapper.Map<ServiceOrderStatusEntity>(newServiceOrderStatus) }
            };
        }
    }
}