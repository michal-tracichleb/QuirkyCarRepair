using AutoMapper;
using QuirkyCarRepair.BLL.Areas.Admin.Interfaces;
using QuirkyCarRepair.BLL.Areas.Identity.DTO;
using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.Identity.Interfaces;
using QuirkyCarRepair.DAL.Areas.Shared.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Exceptions;

namespace QuirkyCarRepair.BLL.Areas.Admin.Services
{
    internal class AdminServie : IAdminService
    {
        private readonly IMapper _mapper;
        private readonly IMarginRepository _marginRepository;
        private readonly IPartCategoryRepository _partCategoryRepository;
        private readonly IMainCategoryServiceRepository _mainCategoryServiceRepository;
        private readonly IAccountRepostiory _accountRepostiory;

        public AdminServie(IMapper mapper,
            IMarginRepository marginRepository,
            IPartCategoryRepository partCategoryRepository,
            IMainCategoryServiceRepository mainCategoryServiceRepository,
            IAccountRepostiory accountRepostiory)
        {
            _mapper = mapper;
            _marginRepository = marginRepository;
            _partCategoryRepository = partCategoryRepository;
            _mainCategoryServiceRepository = mainCategoryServiceRepository;
            _accountRepostiory = accountRepostiory;
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

        public List<UserDetailsDto> GetUsers()
        {
            var users = new List<UserDetailsDto>();
            var roles = _accountRepostiory.GetRoles();

            foreach (var user in _accountRepostiory.GetAll())
            {
                users.Add(new UserDetailsDto()
                {
                    UserId = user.Id,
                    RoleId = user.RoleId,
                    RoleName = roles.First(x => x.Id == user.RoleId).Name,

                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber
                });
            }

            return users;
        }

        public List<RoleDto> GetRoles()
        {
            return _mapper.Map<List<RoleDto>>(_accountRepostiory.GetRoles());
        }
    }
}