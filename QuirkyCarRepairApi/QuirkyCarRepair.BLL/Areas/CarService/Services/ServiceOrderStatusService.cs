using AutoMapper;
using QuirkyCarRepair.BLL.Areas.CarService.Entities;
using QuirkyCarRepair.BLL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Exceptions;

namespace QuirkyCarRepair.BLL.Areas.CarService.Services
{
    internal class ServiceOrderStatusService : IServiceOrderStatusService
    {
        private readonly IServiceOrderStatusRepository _serviceOrderStatusRepository;
        private readonly IMapper _mapper;

        public ServiceOrderStatusService(IServiceOrderStatusRepository serviceOrderStatusRepository,
            IMapper mapper)
        {
            _serviceOrderStatusRepository = serviceOrderStatusRepository;
            _mapper = mapper;
        }

        public ServiceOrderStatusEntity Creat(ServiceOrderStatusEntity serviceOrderStatus)
        {
            var newServiceOrderStatus = _serviceOrderStatusRepository.Creat(_mapper.Map<ServiceOrderStatus>(serviceOrderStatus));
            return _mapper.Map<ServiceOrderStatusEntity>(newServiceOrderStatus);
        }

        public void Delete(int id)
        {
            var serviceOrderStatusToDelete = _serviceOrderStatusRepository.Get(id)
                ?? throw new NotFoundException($"Element with ID {id} was not found.");
            _serviceOrderStatusRepository.Delete(serviceOrderStatusToDelete);
        }

        public ServiceOrderStatusEntity Get(int id)
        {
            var serviceOrderStatus = _serviceOrderStatusRepository.Get(id)
                ?? throw new NotFoundException($"Element with ID {id} was not found.");
            return _mapper.Map<ServiceOrderStatusEntity>(serviceOrderStatus);
        }

        public ICollection<ServiceOrderStatusEntity> GetAll()
        {
            List<ServiceOrderStatus> serviceOrderStatuss = _serviceOrderStatusRepository.GetAll().ToList();
            return _mapper.Map<List<ServiceOrderStatusEntity>>(serviceOrderStatuss);
        }

        public void Update(int id, ServiceOrderStatusEntity serviceOrderStatus)
        {
            if (id != serviceOrderStatus.Id)
            {
                throw new BadRequestException($"The provided ID {id} doesn't match the model's ID {serviceOrderStatus.Id}.");
            }

            if (!_serviceOrderStatusRepository.Exist(id))
            {
                throw new NotFoundException($"Element with ID {id} was not found.");
            }

            _serviceOrderStatusRepository.Update(_mapper.Map<ServiceOrderStatus>(serviceOrderStatus));
        }
    }
}