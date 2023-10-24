using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Repositories
{
    internal class MarginRepository : IMarginRepository
    {
        private readonly QuirkyCarRepairContext _context;

        public MarginRepository(QuirkyCarRepairContext context)
        {
            _context = context;
        }

        public Margin Creat(Margin margin)
        {
            _context.Margins.Add(margin);
            _context.SaveChanges();

            return margin;
        }

        public void Delete(Margin margin)
        {
            _context.Margins.Remove(margin);
            _context.SaveChanges();
        }

        public Margin? Get(int id)
        {
            return _context.Margins.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Margin> GetAll()
        {
            return _context.Margins.ToList();
        }

        public void Update(Margin margin)
        {
            _context.Margins.Update(margin);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Margins.Any(x => x.Id == id);
        }
    }
}