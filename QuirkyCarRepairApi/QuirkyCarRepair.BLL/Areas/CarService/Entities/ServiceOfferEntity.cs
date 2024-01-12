namespace QuirkyCarRepair.BLL.Areas.CarService.Entities
{
    public class ServiceOfferEntity
    {
        public int Id { get; set; }
        public int MainCategoryServiceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}