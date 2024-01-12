using QuirkyCarRepair.DAL.Areas.Identity.Models;
using QuirkyCarRepair.DAL.Areas.Shared;

namespace QuirkyCarRepair.DAL.Areas.CarService.Models
{
    public class ServiceOrderStatus : IModelBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ServiceOrderId { get; set; }

        public DateTime StartDate { get; set; }
        public string Status { get; set; }
        public string? Description { get; set; }

        public virtual ServiceOrder ServiceOrder { get; set; }
        public virtual User User { get; set; }
    }
}