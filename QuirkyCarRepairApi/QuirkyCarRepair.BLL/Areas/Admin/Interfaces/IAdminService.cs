namespace QuirkyCarRepair.BLL.Areas.Admin.Interfaces
{
    public interface IAdminService
    {
        void AssignMarginToMainCategoryService(int marginId, int mainCategoryServiceId);

        void AssignMarginToPartCategory(int marginId, int partCategoryId);
    }
}