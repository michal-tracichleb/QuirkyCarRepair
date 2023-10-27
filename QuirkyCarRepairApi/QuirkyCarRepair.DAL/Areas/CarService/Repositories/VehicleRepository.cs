using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Shared;

namespace QuirkyCarRepair.DAL.Areas.CarService.Repositories
{
    internal class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(QuirkyCarRepairContext context) : base(context)
        {
        }
    }
}