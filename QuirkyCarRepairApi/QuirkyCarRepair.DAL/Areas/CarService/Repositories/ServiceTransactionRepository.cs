using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Shared;

namespace QuirkyCarRepair.DAL.Areas.CarService.Repositories
{
    internal class ServiceTransactionRepository : Repository<ServiceTransaction>, IServiceTransactionRepository
    {
        public ServiceTransactionRepository(QuirkyCarRepairContext context) : base(context)
        {
        }
    }
}