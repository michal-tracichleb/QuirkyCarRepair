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
    }
}