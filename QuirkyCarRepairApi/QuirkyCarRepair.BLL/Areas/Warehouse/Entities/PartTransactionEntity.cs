namespace QuirkyCarRepair.BLL.Areas.Warehouse.Entities
{
    public class PartTransactionEntity
    {
        public int Id { get; set; }
        public int PartId { get; set; }
        public int OperationalDocumentId { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal MarginValue { get; set; }
    }
}