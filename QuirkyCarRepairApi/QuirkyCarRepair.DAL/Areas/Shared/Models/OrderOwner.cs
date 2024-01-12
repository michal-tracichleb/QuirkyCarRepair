using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Identity.Models;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL.Areas.Shared.Models
{
    public class OrderOwner : IModelBase
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        public int? OperationalDocumentId { get; set; }
        public int? ServiceOrderId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public virtual User? User { get; set; }
        public virtual OperationalDocument? OperationalDocument { get; set; }
        public virtual ServiceOrder? ServiceOrder { get; set; }
    }
}