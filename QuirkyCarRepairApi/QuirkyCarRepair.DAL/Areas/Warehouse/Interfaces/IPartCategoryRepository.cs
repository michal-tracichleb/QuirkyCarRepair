using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces
{
    public interface IPartCategoryRepository : IRepository<PartCategory>
    {
        public PartCategory GetWithInclude(int id);

        public List<PartCategory> GetPrimaryCategories();
    }
}