using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Repositories
{
    internal class PartRepository : IPartRepository
    {
        private readonly QuirkyCarRepairContext _context;

        public PartRepository(QuirkyCarRepairContext context)
        {
            _context = context;
        }

        public Part Creat(Part part)
        {
            _context.Parts.Add(part);
            _context.SaveChanges();

            return part;
        }

        public void Delete(Part part)
        {
            _context.Parts.Remove(part);
            _context.SaveChanges();
        }

        public Part? Get(int id)
        {
            return _context.Parts.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Part> GetAll()
        {
            return _context.Parts.ToList();
        }

        public void Update(Part part)
        {
            _context.Parts.Update(part);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Parts.Any(x => x.Id == id);
        }
    }
}