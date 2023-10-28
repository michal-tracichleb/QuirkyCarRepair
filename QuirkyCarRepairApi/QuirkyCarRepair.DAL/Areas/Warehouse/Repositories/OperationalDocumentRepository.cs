using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Repositories
{
    internal class OperationalDocumentRepository : Repository<OperationalDocument>, IOperationalDocumentRepository
    {
        public OperationalDocumentRepository(QuirkyCarRepairContext context) : base(context)
        {
        }
    }
}