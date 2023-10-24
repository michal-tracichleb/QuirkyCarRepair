using AutoMapper;
using QuirkyCarRepair.BLL.Areas.CarService.Entities;
using QuirkyCarRepair.BLL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Exceptions;

namespace QuirkyCarRepair.BLL.Areas.CarService.Services
{
    public class ServiceOrderService : IServiceOrderService
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;
        private readonly IMapper _mapper;

        public ServiceOrderService(IServiceOrderRepository serviceOrderRepository,
            IMapper mapper)
        {
            _serviceOrderRepository = serviceOrderRepository;
            _mapper = mapper;
        }

        public ServiceOrderEntity Creat(ServiceOrderEntity serviceOrder)
        {
            var newServiceOrder = _serviceOrderRepository.Creat(_mapper.Map<ServiceOrder>(serviceOrder));
            return _mapper.Map<ServiceOrderEntity>(newServiceOrder);
        }

        public void Delete(int id)
        {
            var serviceOrderToDelete = _serviceOrderRepository.Get(id)
                ?? throw new NotFoundException($"Element with ID {id} was not found.");
            _serviceOrderRepository.Delete(serviceOrderToDelete);
        }

        public ServiceOrderEntity Get(int id)
        {
            var serviceOrder = _serviceOrderRepository.Get(id)
                ?? throw new NotFoundException($"Element with ID {id} was not found.");
            return _mapper.Map<ServiceOrderEntity>(serviceOrder);
        }

        public ICollection<ServiceOrderEntity> GetAll()
        {
            List<ServiceOrder> serviceOrders = _serviceOrderRepository.GetAll().ToList();
            return _mapper.Map<List<ServiceOrderEntity>>(serviceOrders);
        }

        public void Update(int id, ServiceOrderEntity serviceOrder)
        {
            if (id != serviceOrder.Id)
            {
                throw new BadRequestException($"The provided ID {id} doesn't match the model's ID {serviceOrder.Id}.");
            }

            if (!_serviceOrderRepository.Exist(id))
            {
                throw new NotFoundException($"Element with ID {id} was not found.");
            }

            _serviceOrderRepository.Update(_mapper.Map<ServiceOrder>(serviceOrder));
        }
    }
}