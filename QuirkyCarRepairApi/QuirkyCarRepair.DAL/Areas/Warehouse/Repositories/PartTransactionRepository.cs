using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Repositories
{
    internal class PartTransactionRepository : IPartTransactionRepository
    {
        private readonly QuirkyCarRepairContext _context;

        public PartTransactionRepository(QuirkyCarRepairContext context)
        {
            _context = context;
        }

        public PartTransaction Creat(PartTransaction partTransaction)
        {
            _context.PartTransactions.Add(partTransaction);
            _context.SaveChanges();

            return partTransaction;
        }

        public void Delete(PartTransaction partTransaction)
        {
            _context.PartTransactions.Remove(partTransaction);
            _context.SaveChanges();
        }

        public PartTransaction? Get(int id)
        {
            return _context.PartTransactions.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<PartTransaction> GetAll()
        {
            return _context.PartTransactions.ToList();
        }

        public void Update(PartTransaction partTransaction)
        {
            _context.PartTransactions.Update(partTransaction);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.PartTransactions.Any(x => x.Id == id);
        }
    }
}