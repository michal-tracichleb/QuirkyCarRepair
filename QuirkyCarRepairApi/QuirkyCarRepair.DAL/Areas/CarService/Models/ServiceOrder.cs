using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.CarService.Models
{
    public class ServiceOrder
    {
        public ServiceOrder()
        {
            ServiceOrderStatuses = new HashSet<ServiceOrderStatus>();
            PartTransactions = new HashSet<PartTransaction>();
        }

        public int Id { get; set; }
        public int VehicleId { get; set; }

        public string OrderNumber { get; set; }

        public virtual ICollection<ServiceOrderStatus> ServiceOrderStatuses { get; set; }
        public virtual ICollection<PartTransaction> PartTransactions { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}