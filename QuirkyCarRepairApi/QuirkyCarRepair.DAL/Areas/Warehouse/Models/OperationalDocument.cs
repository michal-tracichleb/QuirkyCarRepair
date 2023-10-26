using QuirkyCarRepair.DAL.Areas.CarService.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Models
{
    public class OperationalDocument
    {
        public OperationalDocument()
        {
            PartTransactions = new HashSet<PartTransaction>();
        }

        public int Id { get; set; }
        public int? ServiceOrderId { get; set; }

        public string DocumentNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Type { get; set; }

        public virtual ServiceOrder ServiceOrder { get; set; }
        public virtual ICollection<PartTransaction> PartTransactions { get; set; }
    }
}