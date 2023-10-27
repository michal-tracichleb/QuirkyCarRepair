using AutoMapper;
using QuirkyCarRepair.BLL.Areas.CarService.Entities;
using QuirkyCarRepair.BLL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Exceptions;

namespace QuirkyCarRepair.BLL.Areas.CarService.Services
{
    internal class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleService(IVehicleRepository vehicleRepository,
            IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public VehicleEntity Creat(VehicleEntity vehicle)
        {
            var newVehicle = _vehicleRepository.Add(_mapper.Map<Vehicle>(vehicle));
            return _mapper.Map<VehicleEntity>(newVehicle);
        }

        public void Delete(int id)
        {
            var vehicleToDelete = _vehicleRepository.Get(id)
                ?? throw new NotFoundException($"Element with ID {id} was not found.");
            _vehicleRepository.Delete(vehicleToDelete);
        }

        public VehicleEntity Get(int id)
        {
            var vehicle = _vehicleRepository.Get(id)
                ?? throw new NotFoundException($"Element with ID {id} was not found.");
            return _mapper.Map<VehicleEntity>(vehicle);
        }

        public ICollection<VehicleEntity> GetAll()
        {
            List<Vehicle> vehicles = _vehicleRepository.GetAll().ToList();
            return _mapper.Map<List<VehicleEntity>>(vehicles);
        }

        public void Update(int id, VehicleEntity vehicle)
        {
            if (id != vehicle.Id)
            {
                throw new BadRequestException($"The provided ID {id} doesn't match the model's ID {vehicle.Id}.");
            }

            if (!_vehicleRepository.Exist(id))
            {
                throw new NotFoundException($"Element with ID {id} was not found.");
            }

            _vehicleRepository.Update(_mapper.Map<Vehicle>(vehicle));
        }
    }
}