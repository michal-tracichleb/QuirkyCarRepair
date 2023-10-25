namespace QuirkyCarRepair.BLL.Areas.CarService.Entities
{
    public class VehicleEntity
    {
        public int Id { get; set; }

        public string? VIN { get; set; }
        public string PlateNumber { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
    }
}