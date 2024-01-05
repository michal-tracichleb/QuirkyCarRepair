using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Shared.Enums;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces
{
    public interface IPartRepository : IRepository<Part>
    {
        public IQueryable<Part> GetPartsByCategories(List<int> categoryIds, SortDirection sortDirection, string? searchPhrase, string? sortBy);
    }
}