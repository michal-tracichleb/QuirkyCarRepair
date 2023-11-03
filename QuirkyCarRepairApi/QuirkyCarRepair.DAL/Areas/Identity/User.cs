using Microsoft.AspNetCore.Identity;
using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Identity
{
    public class User : IdentityUser<int>, IModelBase
    {
        public User() : base()
        {
            OperationalDocuments = new HashSet<OperationalDocument>();
            TransactionStatus = new HashSet<TransactionStatus>();

            ServiceOrders = new HashSet<ServiceOrder>();
            ServiceOrderStatuses = new HashSet<ServiceOrderStatus>();
            Vehicles = new HashSet<Vehicle>();
        }

        public virtual ICollection<OperationalDocument> OperationalDocuments { get; set; }
        public virtual ICollection<TransactionStatus> TransactionStatus { get; set; }

        public virtual ICollection<ServiceOrder> ServiceOrders { get; set; }
        public virtual ICollection<ServiceOrderStatus> ServiceOrderStatuses { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}