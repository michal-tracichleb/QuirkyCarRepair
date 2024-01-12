namespace QuirkyCarRepair.BLL.Areas.CarService.DTO
{
    public class ServiceOrderDTO
    {
        public int ServiceOrderId { get; set; }

        public string DocumentNumber { get; set; }
        public DateTime DateStartRepair { get; set; }

        public DateTime StatusStartDate { get; set; }
        public string Status { get; set; }
        public string OrderDescription { get; set; }

        public OrderOwnerDTO UserData { get; set; }
        public VehicleDataDTO VehicleData { get; set; }
    }
}