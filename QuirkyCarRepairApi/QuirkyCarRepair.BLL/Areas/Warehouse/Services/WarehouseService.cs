using AutoMapper;
using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;
using QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;
using QuirkyCarRepair.DAL.Exceptions;

namespace QuirkyCarRepair.BLL.Areas.Warehouse.Services
{
    internal class WarehouseService : IWarehouseService
    {
        private readonly IMapper _mapper;
        private readonly IPartCategoryRepository _partCategoryRepository;

        public WarehouseService(IMapper mapper, IPartCategoryRepository partCategoryRepository)
        {
            _mapper = mapper;
            _partCategoryRepository = partCategoryRepository;
        }

        public List<PartCategoryEntity> GetPrimaryCategories()
        {
            return _mapper.Map<List<PartCategoryEntity>>(_partCategoryRepository.GetPrimaryCategories());
        }

        public PartCategoryStructure GetPartCategoryStructure(int id)
        {
            if (!_partCategoryRepository.Exist(id))
                throw new NotFoundException("Part category connot found");

            PartCategory partCategory = _partCategoryRepository.GetWithInclude(id);
            PartCategoryStructure partCategoryStructure = _mapper.Map<PartCategoryStructure>(partCategory);

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
    }
}