using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Repositories
{
    internal class TransactionStatusRepository : Repository<TransactionStatus>, ITransactionStatusRepository
    {
        public TransactionStatusRepository(QuirkyCarRepairContext context) : base(context)
        {
        }

        public TransactionStatus GetLatestStatus(int operationalDocumentId)
        {
            return _context.TransactionStatuses
                .Where(x => x.OperationalDocumentid == operationalDocumentId)
                .OrderByDescending(x => x.StartDate).First();
        }
    }
}