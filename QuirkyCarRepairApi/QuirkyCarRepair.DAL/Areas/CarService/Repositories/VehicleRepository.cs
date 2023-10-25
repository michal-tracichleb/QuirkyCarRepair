using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Models;

namespace QuirkyCarRepair.DAL.Areas.CarService.Repositories
{
    internal class VehicleRepository : IVehicleRepository
    {
        private readonly QuirkyCarRepairContext _context;

        public VehicleRepository(QuirkyCarRepairContext context)
        {
            _context = context;
        }

        public Vehicle Creat(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            return vehicle;
        }

        public void Delete(Vehicle vehicle)
        {
            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
        }

        public Vehicle? Get(int id)
        {
            return _context.Vehicles.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Vehicle> GetAll()
        {
            return _context.Vehicles.ToList();
        }

        public void Update(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Vehicles.Any(x => x.Id == id);
        }
    }
}