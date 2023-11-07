using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.CarService.Models
{
    public class ServiceOrder : IModelBase
    {
        public ServiceOrder()
        {
            ServiceOrderStatuses = new HashSet<ServiceOrderStatus>();
            OperationalDocuments = new HashSet<OperationalDocument>();
        }

        public int Id { get; set; }
        public int VehicleId { get; set; }

        public string OrderNumber { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<ServiceOrderStatus> ServiceOrderStatuses { get; set; }
        public virtual ICollection<OperationalDocument> OperationalDocuments { get; set; }
    }
}