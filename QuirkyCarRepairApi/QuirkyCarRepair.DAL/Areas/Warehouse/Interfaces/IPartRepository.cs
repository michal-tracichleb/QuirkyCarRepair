using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces
{
    public interface IPartRepository : IRepository<Part>
    {
        public IQueryable<Part> GetPartsByCategories(List<int> categoryIds);
    }
}