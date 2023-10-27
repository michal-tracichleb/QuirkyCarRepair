using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Shared;

namespace QuirkyCarRepair.DAL.Areas.CarService.Repositories
{
    internal class ServiceOrderRepository : Repository<ServiceOrder>, IServiceOrderRepository
    {
        public ServiceOrderRepository(QuirkyCarRepairContext context) : base(context)
        {
        }
    }
}