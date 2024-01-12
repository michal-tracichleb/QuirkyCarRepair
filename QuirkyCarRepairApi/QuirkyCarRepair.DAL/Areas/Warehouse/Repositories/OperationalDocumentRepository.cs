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
            List<OrderType> orderTypes, List<OrderStatus> orderStates)
        {
            List<string> orderTypesString = new List<string>();
            if (orderTypes != null && orderTypes.Any())
            {
                orderTypesString = orderTypes.Select(x => x.ToString()).ToList();
            }

            List<string> orderStatesString = new List<string>();
            if (orderStates != null && orderStates.Any())
            {
                orderStatesString = orderStates.Select(x => x.ToString()).ToList();
            }

            var query = _context.OperationalDocuments
                .Where(od => !orderTypesString.Any() || orderTypesString.Contains(od.Type))
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

            if (orderStatesString.Any())
            {
                return query.Where(od => od.TransactionStatuses.Any(ts => orderStatesString.Any() == false
                || orderStatesString.Contains(ts.Status)));
            }

            return query;
        }
    }
}