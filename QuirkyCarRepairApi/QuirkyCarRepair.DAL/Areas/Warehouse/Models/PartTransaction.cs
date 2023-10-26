namespace QuirkyCarRepair.DAL.Areas.Warehouse.Models
{
    public class PartTransaction
    {
        public int Id { get; set; }
        public int PartId { get; set; }
        public int OperationalDocumentId { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal MarginValue { get; set; }

        public virtual Part Part { get; set; }
        public virtual OperationalDocument OperationalDocument { get; set; }
    }
}