namespace QuirkyCarRepair.BLL.Areas.Warehouse.DTO
{
    public class CreateServiceOrderDTO
    {
        public DateTime DateStartRepair { get; set; }
        public string OrderDescription { get; set; }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public int VehicleId { get; set; }
        public string Vin { get; set; }
        public string PlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}