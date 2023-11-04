using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Repositories
{
    internal class PartRepository : Repository<Part>, IPartRepository
    {
        public PartRepository(QuirkyCarRepairContext context) : base(context)
        {
        }

        public IQueryable<Part> GetPartsByCategories(List<int> categoryIds)
        {
            return _context.Parts
                .Where(x => categoryIds.Contains(x.PartCategoryId))
                .OrderBy(x => x.Id);
        }
    }
}