using Microsoft.AspNetCore.Identity;
using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Identity
{
    public class User : IdentityUser<int>
    {
        public User() : base()
        {
            OperationalDocuments = new HashSet<OperationalDocument>();
            ServiceOrderStatuses = new HashSet<ServiceOrderStatus>();
            Vehicles = new HashSet<Vehicle>();
            ServiceOrders = new HashSet<ServiceOrder>();
        }

        public virtual ICollection<OperationalDocument> OperationalDocuments { get; set; }
        public virtual ICollection<ServiceOrderStatus> ServiceOrderStatuses { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<ServiceOrder> ServiceOrders { get; set; }
    }
}