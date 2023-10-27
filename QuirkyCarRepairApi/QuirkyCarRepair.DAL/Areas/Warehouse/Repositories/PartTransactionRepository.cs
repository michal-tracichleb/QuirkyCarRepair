using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Repositories
{
    internal class PartTransactionRepository : Repository<PartTransaction>, IPartTransactionRepository
    {
        public PartTransactionRepository(QuirkyCarRepairContext context) : base(context)
        {
        }
    }
}