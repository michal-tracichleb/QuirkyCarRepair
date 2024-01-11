using QuirkyCarRepair.BLL.Areas.Admin.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.Shared.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Exceptions;

namespace QuirkyCarRepair.BLL.Areas.Admin.Services
{
    internal class AdminServie : IAdminService
    {
        private readonly IMarginRepository _marginRepository;
        private readonly IPartCategoryRepository _partCategoryRepository;
        private readonly IMainCategoryServiceRepository _mainCategoryServiceRepository;

        public AdminServie(IMarginRepository marginRepository,
            IPartCategoryRepository partCategoryRepository,
            IMainCategoryServiceRepository mainCategoryServiceRepository)
        {
            _marginRepository = marginRepository;
            _partCategoryRepository = partCategoryRepository;
            _mainCategoryServiceRepository = mainCategoryServiceRepository;
        }

        public void AssignMarginToPartCategory(int marginId, int partCategoryId)
        {
            if (_marginRepository.Exist(marginId) == false)
                throw new NotFoundException("Margin connot found");

            if (_partCategoryRepository.Exist(partCategoryId) == false)
                throw new NotFoundException("Part category connot found");

            var partCategory = _partCategoryRepository.Get(partCategoryId);
            partCategory.MarginId = marginId;

            _partCategoryRepository.Update(partCategory);
        }

        public void AssignMarginToMainCategoryService(int marginId, int mainCategoryServiceId)
        {
            if (_marginRepository.Exist(marginId) == false)
                throw new NotFoundException("Margin connot found");

            if (_mainCategoryServiceRepository.Exist(mainCategoryServiceId) == false)
                throw new NotFoundException("Part category connot found");

            var mainCategoryService = _mainCategoryServiceRepository.Get(mainCategoryServiceId);
            mainCategoryService.MarginId = marginId;

            _mainCategoryServiceRepository.Update(mainCategoryService);
        }
    }
}