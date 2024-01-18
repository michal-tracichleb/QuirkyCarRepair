using QuirkyCarRepair.BLL.Areas.Identity.DTO;

namespace QuirkyCarRepair.BLL.Areas.Admin.Interfaces
{
    public interface IAdminService
    {
        public void AssignMarginToMainCategoryService(int marginId, int mainCategoryServiceId);

        public void AssignMarginToPartCategory(int marginId, int partCategoryId);

        public List<UserDetailsDto> GetUsers();

        public List<RoleDto> GetRoles();
    }
}