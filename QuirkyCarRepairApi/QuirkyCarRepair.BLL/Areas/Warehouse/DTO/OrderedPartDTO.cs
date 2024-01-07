namespace QuirkyCarRepair.BLL.Areas.Warehouse.DTO
{
    public class OrderedPartDTO
    {
        public int PartId { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string UnitType { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal MarginValue { get; set; }
    }
}