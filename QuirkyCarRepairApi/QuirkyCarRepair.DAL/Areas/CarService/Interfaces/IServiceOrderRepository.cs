using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Shared.Enums;

namespace QuirkyCarRepair.DAL.Areas.CarService.Interfaces
{
    public interface IServiceOrderRepository : IRepository<ServiceOrder>
    {
        public IQueryable<ServiceOrder> GetServicesOrdersWithLatestStatus(List<OrderStatus> orderStates, bool anyDate, DateTime? fromDate, DateTime? toDate);

        public IQueryable<ServiceOrder> GetServicesOrdersWithLatestStatusByOwner(int userId, List<OrderStatus> orderStates, bool anyDate, DateTime? fromDate, DateTime? toDate);

        public ServiceOrder? GetWithInclude(int id);
    }
}