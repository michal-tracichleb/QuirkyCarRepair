namespace QuirkyCarRepair.BLL.Areas.Warehouse.Entities
{
    public class PartCategoryEntity
    {
        public int Id { get; set; }
        public int MarginId { get; set; }

        public int? ParentCategoryId { get; set; }
        public string Name { get; set; }
    }
}