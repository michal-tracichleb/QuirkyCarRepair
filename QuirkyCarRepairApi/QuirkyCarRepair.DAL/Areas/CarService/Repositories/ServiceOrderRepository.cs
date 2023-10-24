using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Models;

namespace QuirkyCarRepair.DAL.Areas.CarService.Repositories
{
    internal class ServiceOrderRepository : IServiceOrderRepository
    {
        private readonly QuirkyCarRepairContext _context;

        public ServiceOrderRepository(QuirkyCarRepairContext context)
        {
            _context = context;
        }

        public ServiceOrder Creat(ServiceOrder serviceOrder)
        {
            _context.ServiceOrders.Add(serviceOrder);
            _context.SaveChanges();

            return serviceOrder;
        }

        public void Delete(ServiceOrder serviceOrder)
        {
            _context.ServiceOrders.Remove(serviceOrder);
            _context.SaveChanges();
        }

        public ServiceOrder? Get(int id)
        {
            return _context.ServiceOrders.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<ServiceOrder> GetAll()
        {
            return _context.ServiceOrders.ToList();
        }

        public void Update(ServiceOrder serviceOrder)
        {
            _context.ServiceOrders.Update(serviceOrder);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.ServiceOrders.Any(x => x.Id == id);
        }
    }
}