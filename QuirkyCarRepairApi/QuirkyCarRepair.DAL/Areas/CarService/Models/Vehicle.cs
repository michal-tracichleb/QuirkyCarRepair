namespace QuirkyCarRepair.DAL.Areas.CarService.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            ServiceOrders = new HashSet<ServiceOrder>();
        }

        public int Id { get; set; }

        public string VIN { get; set; }
        public string PlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public ICollection<ServiceOrder> ServiceOrders { get; set; }
    }
}