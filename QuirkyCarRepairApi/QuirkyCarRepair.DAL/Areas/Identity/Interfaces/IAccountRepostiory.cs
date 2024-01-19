using QuirkyCarRepair.DAL.Areas.Identity.Models;
using QuirkyCarRepair.DAL.Areas.Shared;

namespace QuirkyCarRepair.DAL.Areas.Identity.Interfaces
{
    public interface IAccountRepostiory : IRepository<User>
    {
        public User? GetByEmail(string email);

        public List<Role> GetRoles();
    }
}