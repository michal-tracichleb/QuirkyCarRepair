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

        public List<PartTransaction> GetByOperationalDocument(int operationalDocumentId)
        {
            return _context.PartTransactions
                .Where(x => x.OperationalDocumentId == operationalDocumentId).ToList();
        }
    }
}