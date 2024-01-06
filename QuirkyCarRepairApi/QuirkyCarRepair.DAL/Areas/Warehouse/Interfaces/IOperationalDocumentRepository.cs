using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Shared.Enums;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces
{
    public interface IOperationalDocumentRepository : IRepository<OperationalDocument>
    {
        public IQueryable<OperationalDocument> GetOperationalDocumentsWithLatestTransactionStatus(
            List<TransactionType> transactionTypes, List<TransactionState> transactionStates);
    }
}