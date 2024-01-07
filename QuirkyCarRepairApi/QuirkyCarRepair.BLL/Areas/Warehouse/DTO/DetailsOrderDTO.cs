namespace QuirkyCarRepair.BLL.Areas.Warehouse.DTO
{
    public class DetailsOrderDTO
    {
        public int OperationalDocumentId { get; set; }

        public string DocumentNumber { get; set; }
        public DateTime TransactionStartDate { get; set; }
        public string Type { get; set; }

        public DateTime StatusStartDate { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public List<OrderedPartDTO> OrderedParts { get; set; }
    }
}