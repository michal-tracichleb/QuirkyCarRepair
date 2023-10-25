namespace QuirkyCarRepair.API.DTO.CarService
{
    public class VehicleDTO
    {
        public int Id { get; set; }

        public string? VIN { get; set; }
        public string PlateNumber { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
    }
}