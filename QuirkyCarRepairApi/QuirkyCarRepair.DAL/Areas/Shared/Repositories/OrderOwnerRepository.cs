using QuirkyCarRepair.DAL.Areas.Shared.Interfaces;
using QuirkyCarRepair.DAL.Areas.Shared.Models;

namespace QuirkyCarRepair.DAL.Areas.Shared.Repositories
{
    internal class OrderOwnerRepository : Repository<OrderOwner>, IOrderOwnerRepository
    {
        public OrderOwnerRepository(QuirkyCarRepairContext context) : base(context)
        {
        }
    }
}