using Microsoft.EntityFrameworkCore;
using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Shared.Enums;

namespace QuirkyCarRepair.DAL.Areas.CarService.Repositories
{
    internal class ServiceOrderRepository : Repository<ServiceOrder>, IServiceOrderRepository
    {
        public ServiceOrderRepository(QuirkyCarRepairContext context) : base(context)
        {
        }

        public IQueryable<ServiceOrder> GetServicesOrdersWithLatestStatus(List<OrderStatus> orderStates, bool anyDate, DateTime? fromDate, DateTime? toDate)
        {
            List<string> orderStatesString = new List<string>();
            if (orderStates != null && orderStates.Any())
            {
                orderStatesString = orderStates.Select(x => x.ToString()).ToList();
            }

            var query = _context.ServiceOrders
                .Where(x => anyDate
                    || (x.DateStartRepair.AddHours(1) > fromDate && x.DateStartRepair.AddHours(-1) < toDate))
                .Select(od => new ServiceOrder
                {
                    Id = od.Id,
                    VehicleId = od.VehicleId,
                    OrderOwnerId = od.OrderOwnerId,
                    OrderNumber = od.OrderNumber,
                    DateStartRepair = od.DateStartRepair,
                    Vehicle = od.Vehicle,
                    OrderOwner = od.OrderOwner,
                    ServiceOrderStatuses = od.ServiceOrderStatuses
                        .OrderByDescending(ts => ts.StartDate)
                        .Take(1)
                        .ToList()
                });

            if (orderStatesString.Any())
            {
                return query.Where(od => od.ServiceOrderStatuses.Any(s => orderStatesString.Contains(s.Status)));
            }

            return query;
        }

        public ServiceOrder? GetWithInclude(int id)
        {
            return _context.ServiceOrders
                .Include(x => x.Vehicle)
                .Include(x => x.OrderOwner)
                .Include(x => x.ServiceTransactions)
                    .ThenInclude(x => x.ServiceOffer)
                .Include(x => x.OperationalDocuments)
                    .ThenInclude(x => x.PartTransactions)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}