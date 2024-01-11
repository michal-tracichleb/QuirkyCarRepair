using QuirkyCarRepair.DAL.Areas.Shared;

namespace QuirkyCarRepair.DAL.Areas.CarService.Models
{
    public class ServiceTransaction : IModelBase
    {
        public int Id { get; set; }
        public int ServiceOfferId { get; set; }
        public int ServiceOrderId { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal MarginValue { get; set; }

        public virtual ServiceOffer ServiceOffer { get; set; }
        public virtual ServiceOrder ServiceOrder { get; set; }
    }
}