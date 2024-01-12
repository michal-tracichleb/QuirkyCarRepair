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
            if (marginId != 0 && _marginRepository.Exist(marginId) == false)
                throw new NotFoundException("Margin connot found");

            var partCategory = _partCategoryRepository.Get(partCategoryId);
            if (partCategory is null)
                throw new NotFoundException("Part category connot found");

            partCategory.MarginId = marginId == 0 ? null : marginId;

            _partCategoryRepository.Update(partCategory);
        }

        public void AssignMarginToMainCategoryService(int marginId, int mainCategoryServiceId)
        {
            if (marginId != 0 && _marginRepository.Exist(marginId) == false)
                throw new NotFoundException("Margin connot found");

            var mainCategoryService = _mainCategoryServiceRepository.Get(mainCategoryServiceId);
            if (mainCategoryService is null)
                throw new NotFoundException("Main category service connot found");

            mainCategoryService.MarginId = marginId == 0 ? null : marginId;

            _mainCategoryServiceRepository.Update(mainCategoryService);
        }
    }
}