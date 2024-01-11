using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Shared.Models
{
    public class Margin : IModelBase
    {
        public Margin()
        {
            PartCategories = new HashSet<PartCategory>();
            MainCategoriesServices = new HashSet<MainCategoryService>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Value { get; set; }

        public virtual ICollection<PartCategory> PartCategories { get; set; }
        public virtual ICollection<MainCategoryService> MainCategoriesServices { get; set; }
    }
}