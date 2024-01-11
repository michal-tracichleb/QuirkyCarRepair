using QuirkyCarRepair.DAL.Areas.Shared;

namespace QuirkyCarRepair.DAL.Areas.CarService.Models
{
    public class ServiceOffer : IModelBase
    {
        public int Id { get; set; }
        public int MainCategoryServiceId { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual MainCategoryService MainCategoryService { get; set; }
    }
}