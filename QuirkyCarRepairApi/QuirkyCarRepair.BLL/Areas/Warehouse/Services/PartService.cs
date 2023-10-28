using AutoMapper;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;
using QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;
using QuirkyCarRepair.DAL.Exceptions;

namespace QuirkyCarRepair.BLL.Areas.Warehouse.Services
{
    internal class PartService : IPartService
    {
        private readonly IPartRepository _partRepository;
        private readonly IMapper _mapper;

        public PartService(IPartRepository partRepository,
            IMapper mapper)
        {
            _partRepository = partRepository;
            _mapper = mapper;
        }

        public PartEntity Creat(PartEntity part)
        {
            var newPart = _partRepository.Add(_mapper.Map<Part>(part));
            return _mapper.Map<PartEntity>(newPart);
        }

        public void Delete(int id)
        {
            var partToDelete = _partRepository.Get(id)
                ?? throw new NotFoundException($"Element with ID {id} was not found.");
            _partRepository.Delete(partToDelete);
        }

        public PartEntity Get(int id)
        {
            var part = _partRepository.Get(id)
                ?? throw new NotFoundException($"Element with ID {id} was not found.");
            return _mapper.Map<PartEntity>(part);
        }

        public ICollection<PartEntity> GetAll()
        {
            List<Part> parts = _partRepository.GetAll().ToList();
            return _mapper.Map<List<PartEntity>>(parts);
        }

        public void Update(int id, PartEntity part)
        {
            if (id != part.Id)
            {
                throw new BadRequestException($"The provided ID {id} doesn't match the model's ID {part.Id}.");
            }

            if (!_partRepository.Exist(id))
            {
                throw new NotFoundException($"Element with ID {id} was not found.");
            }

            _partRepository.Update(_mapper.Map<Part>(part));
        }
    }
}