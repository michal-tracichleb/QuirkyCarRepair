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
    }
}