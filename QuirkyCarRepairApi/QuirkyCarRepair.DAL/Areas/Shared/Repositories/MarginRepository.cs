using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Shared.Interfaces;
using QuirkyCarRepair.DAL.Areas.Shared.Models;

namespace QuirkyCarRepair.DAL.Areas.Shared.Repositories
{
    internal class MarginRepository : Repository<Margin>, IMarginRepository
    {
        public MarginRepository(QuirkyCarRepairContext context) : base(context)
        {
        }
    }
}