using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Repositories
{
    internal class MarginRepository : Repository<Margin>, IMarginRepository
    {
        public MarginRepository(QuirkyCarRepairContext context) : base(context)
        {
        }
    }
}