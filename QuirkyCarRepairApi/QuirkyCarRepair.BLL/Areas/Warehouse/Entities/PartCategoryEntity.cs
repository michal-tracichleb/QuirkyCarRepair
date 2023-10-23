namespace QuirkyCarRepair.BLL.Areas.Warehouse.Entites
{
    public class PartCategoryEntity
    {
        public int Id { get; set; }

        public int? ParentCategoryId { get; set; }
        public string Name { get; set; }
    }
}