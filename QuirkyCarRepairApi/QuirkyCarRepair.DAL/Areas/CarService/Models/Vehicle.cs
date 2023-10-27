using QuirkyCarRepair.DAL.Areas.Identity;
using QuirkyCarRepair.DAL.Areas.Shared;

namespace QuirkyCarRepair.DAL.Areas.CarService.Models
{
    public class Vehicle : IModelBase
    {
        public Vehicle()
        {
            ServiceOrders = new HashSet<ServiceOrder>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }

        public string? VIN { get; set; }
        public string PlateNumber { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ServiceOrder> ServiceOrders { get; set; }
    }
}