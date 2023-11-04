using AutoMapper;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;
using QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;
using QuirkyCarRepair.DAL.Exceptions;

namespace QuirkyCarRepair.BLL.Areas.Warehouse.Services
{
    internal class PartCategoryService : IPartCategoryService
    {
        private readonly IPartCategoryRepository _partCategoryRepository;
        private readonly IMapper _mapper;

        public PartCategoryService(IPartCategoryRepository partCategoryRepository,
            IMapper mapper)
        {
            _partCategoryRepository = partCategoryRepository;
            _mapper = mapper;
        }

        public PartCategoryEntity Creat(PartCategoryEntity partCategory)
        {
            var newPartCategory = _partCategoryRepository.Add(_mapper.Map<PartCategory>(partCategory));
            return _mapper.Map<PartCategoryEntity>(newPartCategory);
        }

        public void Delete(int id)
        {
            var partCategoryToDelete = _partCategoryRepository.Get(id)
                ?? throw new NotFoundException($"Element with ID {id} was not found.");
            _partCategoryRepository.Delete(partCategoryToDelete);
        }

        public PartCategoryEntity Get(int id)
        {
            var partCategory = _partCategoryRepository.Get(id)
                ?? throw new NotFoundException($"Element with ID {id} was not found.");
            return _mapper.Map<PartCategoryEntity>(partCategory);
        }

        public ICollection<PartCategoryEntity> GetAll()
        {
            List<PartCategory> partCategories = _partCategoryRepository.GetAll().ToList();
            return _mapper.Map<List<PartCategoryEntity>>(partCategories);
        }

        public void Update(int id, PartCategoryEntity partCategory)
        {
            if (id != partCategory.Id)
            {
                throw new BadRequestException($"The provided ID {id} doesn't match the model's ID {partCategory.Id}.");
            }

            if (!_partCategoryRepository.Exist(id))
            {
                throw new NotFoundException($"Element with ID {id} was not found.");
            }

            _partCategoryRepository.Update(_mapper.Map<PartCategory>(partCategory));
        }
    }
}