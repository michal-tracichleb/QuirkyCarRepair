using AutoMapper;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;
using QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;
using QuirkyCarRepair.DAL.Exceptions;

namespace QuirkyCarRepair.BLL.Areas.Warehouse.Services
{
    internal class MarginService : IMarginService
    {
        private readonly IMarginRepository _marginRepository;
        private readonly IMapper _mapper;

        public MarginService(IMarginRepository marginRepository,
            IMapper mapper)
        {
            _marginRepository = marginRepository;
            _mapper = mapper;
        }

        public MarginEntity Creat(MarginEntity margin)
        {
            var newMargin = _marginRepository.Add(_mapper.Map<Margin>(margin));
            return _mapper.Map<MarginEntity>(newMargin);
        }

        public void Delete(int id)
        {
            var marginToDelete = _marginRepository.Get(id)
                ?? throw new NotFoundException($"Element with ID {id} was not found.");
            _marginRepository.Delete(marginToDelete);
        }

        public MarginEntity Get(int id)
        {
            var margin = _marginRepository.Get(id)
                ?? throw new NotFoundException($"Element with ID {id} was not found.");
            return _mapper.Map<MarginEntity>(margin);
        }

        public ICollection<MarginEntity> GetAll()
        {
            List<Margin> margins = _marginRepository.GetAll().ToList();
            return _mapper.Map<List<MarginEntity>>(margins);
        }

        public void Update(int id, MarginEntity margin)
        {
            if (id != margin.Id)
            {
                throw new BadRequestException($"The provided ID {id} doesn't match the model's ID {margin.Id}.");
            }

            if (!_marginRepository.Exist(id))
            {
                throw new NotFoundException($"Element with ID {id} was not found.");
            }

            _marginRepository.Update(_mapper.Map<Margin>(margin));
        }
    }
}