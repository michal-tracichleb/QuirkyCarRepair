namespace QuirkyCarRepair.API.DTO.Warehouse
{
    public class PartCategoryDTO
    {
        public int Id { get; set; }

        public int? ParentCategoryId { get; set; }
        public string Name { get; set; }
    }
}