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
    }
}