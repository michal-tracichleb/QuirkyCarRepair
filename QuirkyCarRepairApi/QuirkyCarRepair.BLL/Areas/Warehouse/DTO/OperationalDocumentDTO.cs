namespace QuirkyCarRepair.BLL.Areas.Warehouse.DTO
{
    public class OperationalDocumentDTO
    {
        public int Id { get; set; }

        public string DocumentNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Type { get; set; }

        public DateTime StartDate { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}