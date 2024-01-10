using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Identity.Models;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Seeder
{
    public class DataSeeder
    {
        private readonly QuirkyCarRepairContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public DataSeeder(QuirkyCarRepairContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public List<T> LoadDataFromJsonFile<T>(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        public void SeedDatabase()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seeder", "Data");

            if (_context.Database.CanConnect())
            {
                if (!_context.Roles.Any())
                {
                    var roles = GetRoles();
                    _context.Roles.AddRange(roles);
                    _context.SaveChanges();
                }

                if (!_context.Users.Any())
                {
                    var users = GetUsers();
                    _context.Users.AddRange(users);
                    _context.SaveChanges();
                }

                if (!_context.PartCategories.Any())
                {
                    string filePath = Path.Combine(folderPath, "PartCategoryWithParts.json");
                    var partCategories = LoadDataFromJsonFile<PartCategory>(filePath);
                    _context.AddRange(partCategories);
                    _context.SaveChanges();
                }

                if (!_context.MainCategoriesServices.Any())
                {
                    string filePath = Path.Combine(folderPath, "ServiceCategories.json");
                    var mainCategoriesServices = LoadDataFromJsonFile<MainCategoryService>(filePath);
                    _context.AddRange(mainCategoriesServices);
                    _context.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            return new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Storekeeper"
                },
                new Role()
                {
                    Name = "Mechanic"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };
        }

        private IEnumerable<User> GetUsers()
        {
            var user = new User()
            {
                UserName = "User",
                Email = "user@user.com",
                EmailIsConfirmed = true,
                RoleId = 1,
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, "User123!");

            var storekeeper = new User()
            {
                UserName = "Storekeeper",
                Email = "storekeeper@storekeeper.com",
                EmailIsConfirmed = true,
                RoleId = 2,
            };
            storekeeper.PasswordHash = _passwordHasher.HashPassword(user, "Storekeeper123!");

            var mechanic = new User()
            {
                UserName = "Mechanic",
                Email = "mechanic@mechanic.com",
                EmailIsConfirmed = true,
                RoleId = 3,
            };
            mechanic.PasswordHash = _passwordHasher.HashPassword(user, "Mechanic123!");

            var admin = new User()
            {
                UserName = "Admin",
                Email = "admin@admin.com",
                EmailIsConfirmed = true,
                RoleId = 4,
            };
            admin.PasswordHash = _passwordHasher.HashPassword(user, "Admin123!");

            var users = new List<User>() { user, storekeeper, mechanic, admin };

            return users;
        }
    }
}