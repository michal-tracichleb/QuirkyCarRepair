using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;

namespace QuirkyCarRepair.BLL.Areas.Warehouse.DTO
{
    public class PartCategoryStructureDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PartCategoryEntity ParentCategory { get; set; }
        public List<PartCategoryEntity> Subcategories { get; set; }
        public List<PartCategoryEntity> SiblingCategories { get; set; }
    }
}