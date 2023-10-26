namespace QuirkyCarRepair.BLL.Areas.Warehouse.Entities
{
    public class OperationalDocumentEntity
    {
        public int Id { get; set; }
        public int? ServiceOrderId { get; set; }

        public string DocumentNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Type { get; set; }
    }
}