using Newtonsoft.Json;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Seeder
{
    public class DataSeeder
    {
        private readonly QuirkyCarRepairContext _context;

        public DataSeeder(QuirkyCarRepairContext context)
        {
            _context = context;
        }

        public List<T> LoadDataFromJsonFile<T>(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        public void SeedDatabase()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seeder", "Data");
            SeedPartCategoryWithParts(folderPath);
        }

        private void SeedPartCategoryWithParts(string folderPath)
        {
            if (!_context.PartCategories.Any())
            {
                string filePath = Path.Combine(folderPath, "PartCategoryWithParts.json");
                var partCategories = LoadDataFromJsonFile<PartCategory>(filePath);
                _context.AddRange(partCategories);
                _context.SaveChanges();
            }
        }
    }
}