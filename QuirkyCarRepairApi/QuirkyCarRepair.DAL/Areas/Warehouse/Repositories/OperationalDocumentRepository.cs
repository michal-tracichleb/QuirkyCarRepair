using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Shared.Enums;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Repositories
{
    internal class OperationalDocumentRepository : Repository<OperationalDocument>, IOperationalDocumentRepository
    {
        public OperationalDocumentRepository(QuirkyCarRepairContext context) : base(context)
        {
        }

        public IQueryable<OperationalDocument> GetOperationalDocumentsWithLatestTransactionStatus(
            List<TransactionType> transactionTypes, List<TransactionState> transactionStates)
        {
            List<string> transactionTypesString = new List<string>();
            if (transactionTypes != null && transactionTypes.Any())
            {
                transactionTypesString = transactionTypes.Select(x => x.ToString()).ToList();
            }

            List<string> transactionStatesString = new List<string>();
            if (transactionStates != null && transactionStates.Any())
            {
                transactionStatesString = transactionStates.Select(x => x.ToString()).ToList();
            }

            var query = _context.OperationalDocuments
                .Where(od => !transactionTypesString.Any() || transactionTypesString.Contains(od.Type))
                .Select(od => new OperationalDocument
                {
                    Id = od.Id,
                    ServiceOrderId = od.ServiceOrderId,
                    DocumentNumber = od.DocumentNumber,
                    TransactionDate = od.TransactionDate,
                    Type = od.Type,
                    ServiceOrder = od.ServiceOrder,
                    PartTransactions = od.PartTransactions,
                    TransactionStatuses = od.TransactionStatuses
                        .OrderByDescending(ts => ts.StartDate)
                        .Take(1)
                        .ToList()
                });

            if (transactionStatesString.Any())
            {
                return query.Where(od => od.TransactionStatuses.Any(ts => transactionStatesString.Any() == false
                || transactionStatesString.Contains(ts.Status)));
            }

            return query;
        }
    }
}