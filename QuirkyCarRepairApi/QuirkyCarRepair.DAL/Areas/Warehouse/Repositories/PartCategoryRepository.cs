using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Repositories
{
    internal class PartCategoryRepository : IPartCategoryRepository
    {
        private readonly QuirkyCarRepairContext _context;

        public PartCategoryRepository(QuirkyCarRepairContext context)
        {
            _context = context;
        }

        public PartCategory Creat(PartCategory partCategory)
        {
            _context.PartCategories.Add(partCategory);
            _context.SaveChanges();

            return partCategory;
        }

        public void Delete(PartCategory partCategory)
        {
            _context.PartCategories.Remove(partCategory);
            _context.SaveChanges();
        }

        public PartCategory? Get(int id)
        {
            return _context.PartCategories.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<PartCategory> GetAll()
        {
            return _context.PartCategories.ToList();
        }

        public void Update(PartCategory partCategory)
        {
            _context.PartCategories.Update(partCategory);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.PartCategories.Any(x => x.Id == id);
        }
    }
}