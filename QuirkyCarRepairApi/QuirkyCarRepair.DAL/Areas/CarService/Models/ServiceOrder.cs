namespace QuirkyCarRepair.DAL.Areas.CarService.Models
{
    public class ServiceOrder
    {
        public ServiceOrder()
        {
            ServiceOrderStatuses = new HashSet<ServiceOrderStatus>();
        }

        public int Id { get; set; }
        public int VehicleId { get; set; }

        public string OrderNumber { get; set; }

        public virtual ICollection<ServiceOrderStatus> ServiceOrderStatuses { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}