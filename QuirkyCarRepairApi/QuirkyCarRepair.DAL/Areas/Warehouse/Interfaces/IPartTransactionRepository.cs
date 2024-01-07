using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces
{
    public interface IPartTransactionRepository : IRepository<PartTransaction>
    {
        public List<PartTransaction> GetByOperationalDocument(int operationalDocumentId);
    }
}