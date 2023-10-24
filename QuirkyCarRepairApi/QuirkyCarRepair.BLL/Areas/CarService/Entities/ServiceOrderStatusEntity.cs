namespace QuirkyCarRepair.BLL.Areas.CarService.Entities
{
    public class ServiceOrderStatusEntity
    {
        public int Id { get; set; }
        public int ServiceOrderId { get; set; }

        public DateTime StartDate { get; set; }
        public string Status { get; set; }
        public string? Description { get; set; }
    }
}