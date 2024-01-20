using Microsoft.EntityFrameworkCore;
using QuirkyCarRepair.DAL.Areas.Identity.Interfaces;
using QuirkyCarRepair.DAL.Areas.Identity.Models;
using QuirkyCarRepair.DAL.Areas.Shared;

namespace QuirkyCarRepair.DAL.Areas.Identity.Repositories
{
    internal class AccountRepostiory : Repository<User>, IAccountRepostiory
    {
        public AccountRepostiory(QuirkyCarRepairContext context) : base(context)
        {
        }

        public User? GetByEmail(string email)
        {
            return _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == email);
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}