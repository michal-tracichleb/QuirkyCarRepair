using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Models;

namespace QuirkyCarRepair.DAL.Areas.CarService.Repositories
{
    internal class ServiceOrderStatusRepository : IServiceOrderStatusRepository
    {
        private readonly QuirkyCarRepairContext _context;

        public ServiceOrderStatusRepository(QuirkyCarRepairContext context)
        {
            _context = context;
        }

        public ServiceOrderStatus Creat(ServiceOrderStatus serviceOrderStatus)
        {
            _context.ServiceOrderStatuses.Add(serviceOrderStatus);
            _context.SaveChanges();

            return serviceOrderStatus;
        }

        public void Delete(ServiceOrderStatus serviceOrderStatus)
        {
            _context.ServiceOrderStatuses.Remove(serviceOrderStatus);
            _context.SaveChanges();
        }

        public ServiceOrderStatus? Get(int id)
        {
            return _context.ServiceOrderStatuses.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<ServiceOrderStatus> GetAll()
        {
            return _context.ServiceOrderStatuses.ToList();
        }

        public void Update(ServiceOrderStatus serviceOrderStatus)
        {
            _context.ServiceOrderStatuses.Update(serviceOrderStatus);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.ServiceOrderStatuses.Any(x => x.Id == id);
        }
    }
}