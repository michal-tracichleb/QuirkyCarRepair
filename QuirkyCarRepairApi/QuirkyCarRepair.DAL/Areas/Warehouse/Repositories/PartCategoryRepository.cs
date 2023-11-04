using Microsoft.EntityFrameworkCore;
using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Repositories
{
    internal class PartCategoryRepository : Repository<PartCategory>, IPartCategoryRepository
    {
        public PartCategoryRepository(QuirkyCarRepairContext context) : base(context)
        {
        }

        public PartCategory GetWithInclude(int id)
        {
            return _context.PartCategories
                .Include(x => x.Subcategories)
                .Include(x => x.ParentCategory)
                .First(x => x.Id == id);
        }

        public List<PartCategory> GetPrimaryCategories()
        {
            return _context.PartCategories.Where(x => x.ParentCategoryId == null).ToList();
        }

        public PartCategory GetWithSubcategories(int id)
        {
            return _context.PartCategories
                .Include(x => x.Subcategories)
                    .ThenInclude(x => x.Subcategories)
                        .ThenInclude(x => x.Subcategories)
                            .ThenInclude(x => x.Subcategories)
                .First(x => x.Id == id);
        }
    }
}