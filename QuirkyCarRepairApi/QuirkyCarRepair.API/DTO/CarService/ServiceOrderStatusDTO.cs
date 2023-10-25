namespace QuirkyCarRepair.API.DTO.CarService
{
    public class ServiceOrderStatusDTO
    {
        public int Id { get; set; }
        public int ServiceOrderId { get; set; }

        public DateTime StartDate { get; set; }
        public string Status { get; set; }
        public string? Description { get; set; }
    }
}