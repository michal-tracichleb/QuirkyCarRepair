using QuirkyCarRepair.DAL.Areas.Identity;
using QuirkyCarRepair.DAL.Areas.Shared;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Models
{
    public class TransactionStatus : IModelBase
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int OperationalDocumentid { get; set; }

        public DateTime StartDate { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual OperationalDocument OperationalDocument { get; set; }
    }
}