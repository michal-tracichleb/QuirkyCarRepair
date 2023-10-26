using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Repositories
{
    internal class OperationalDocumentRepository : IOperationalDocumentRepository
    {
        private readonly QuirkyCarRepairContext _context;

        public OperationalDocumentRepository(QuirkyCarRepairContext context)
        {
            _context = context;
        }

        public OperationalDocument Creat(OperationalDocument operationalDocument)
        {
            _context.OperationalDocuments.Add(operationalDocument);
            _context.SaveChanges();

            return operationalDocument;
        }

        public void Delete(OperationalDocument operationalDocument)
        {
            _context.OperationalDocuments.Remove(operationalDocument);
            _context.SaveChanges();
        }

        public OperationalDocument? Get(int id)
        {
            return _context.OperationalDocuments.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<OperationalDocument> GetAll()
        {
            return _context.OperationalDocuments.ToList();
        }

        public void Update(OperationalDocument operationalDocument)
        {
            _context.OperationalDocuments.Update(operationalDocument);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.OperationalDocuments.Any(x => x.Id == id);
        }
    }
}