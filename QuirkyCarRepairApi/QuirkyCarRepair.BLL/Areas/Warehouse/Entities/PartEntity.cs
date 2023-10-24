namespace QuirkyCarRepair.BLL.Areas.Warehouse.Entities
{
    public class PartEntity
    {
        public int Id { get; set; }

        public int? ParentCategoryId { get; set; }
        public string Name { get; set; }
    }
}