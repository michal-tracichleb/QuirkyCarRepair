using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Shared.Models;

namespace QuirkyCarRepair.DAL.Areas.CarService.Models
{
    public class MainCategoryService : IModelBase
    {
        public MainCategoryService()
        {
            ServiceOffers = new HashSet<ServiceOffer>();
        }

        public int Id { get; set; }
        public int? MarginId { get; set; }

        public string Name { get; set; }

        public virtual Margin Margin { get; set; }
        public virtual ICollection<ServiceOffer> ServiceOffers { get; set; }
    }
}