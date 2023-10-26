using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using QuirkyCarRepair.DAL.Areas.Identity;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Seeder
{
    public class DataSeeder
    {
        private readonly QuirkyCarRepairContext _context;

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public DataSeeder(QuirkyCarRepairContext context,
            RoleManager<IdentityRole<int>> roleManager,
            UserManager<User> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public List<T> LoadDataFromJsonFile<T>(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        public void SeedDatabase()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seeder", "Data");

            if (!_context.PartCategories.Any())
            {
                string filePath = Path.Combine(folderPath, "PartCategory.json");
                var data = LoadDataFromJsonFile<PartCategory>(filePath);
                _context.PartCategories.AddRange(data);
                _context.SaveChanges();
            }
        }

        public async Task SeedUsers()
        {
            string adminRole = "admin";
            string adminPassword = "Admin123!";
            var admin = new User
            {
                UserName = "Admin",
                Email = "admin@admin.com",
                PhoneNumber = "999999999",
                EmailConfirmed = true
            };

            string userRole = "user";
            string userPassword = "User123!";
            var user = new User
            {
                UserName = "User",
                Email = "user@user.com",
                PhoneNumber = "111222333",
                EmailConfirmed = true
            };

            string mechanicRole = "mechanic";
            string mechanicPassword = "Mechanic123!";
            var mechanic = new User
            {
                UserName = "Mechanic",
                Email = "mechanic@mechanic.com",
                PhoneNumber = "333222333",
                EmailConfirmed = true
            };

            string storekeeperRole = "storekeeper";
            string storekeeperPassword = "Storekeeper123!";
            var storekeeper = new User
            {
                UserName = "Storekeeper",
                Email = "storekeeper@storekeeper.com",
                PhoneNumber = "333333333",
                EmailConfirmed = true
            };

            if (await _roleManager.FindByNameAsync(adminRole) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole<int>
                {
                    Name = adminRole,
                    NormalizedName = adminRole.ToUpper()
                });
            }

            if (await _userManager.FindByNameAsync("Admin") == null)
            {
                var result = await _userManager.CreateAsync(admin);
                if (result.Succeeded)
                {
                    await _userManager.AddPasswordAsync(admin, adminPassword);
                    await _userManager.AddToRoleAsync(admin, adminRole);
                }
            }

            if (await _roleManager.FindByNameAsync(userRole) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole<int>
                {
                    Name = userRole,
                    NormalizedName = userRole.ToUpper()
                });
            }

            if (await _userManager.FindByNameAsync("User") == null)
            {
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddPasswordAsync(user, userPassword);
                    await _userManager.AddToRoleAsync(user, userRole);
                }
            }

            if (await _roleManager.FindByNameAsync(mechanicRole) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole<int>
                {
                    Name = mechanicRole,
                    NormalizedName = mechanicRole.ToUpper()
                });
            }

            if (await _userManager.FindByNameAsync("Mechanic") == null)
            {
                var result = await _userManager.CreateAsync(mechanic);
                if (result.Succeeded)
                {
                    await _userManager.AddPasswordAsync(mechanic, mechanicPassword);
                    await _userManager.AddToRoleAsync(mechanic, mechanicRole);
                }
            }

            if (await _roleManager.FindByNameAsync(storekeeperRole) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole<int>
                {
                    Name = storekeeperRole,
                    NormalizedName = storekeeperRole.ToUpper()
                });
            }

            if (await _userManager.FindByNameAsync("Storekeeper") == null)
            {
                var result = await _userManager.CreateAsync(storekeeper);
                if (result.Succeeded)
                {
                    await _userManager.AddPasswordAsync(storekeeper, storekeeperPassword);
                    await _userManager.AddToRoleAsync(storekeeper, storekeeperRole);
                }
            }
        }
    }
}