using QuirkyCarRepair.DAL.Areas.Shared;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Models
{
    public class Part : IModelBase
    {
        public Part()
        {
            PartTransactions = new HashSet<PartTransaction>();
        }

        public int Id { get; set; }
        public int PartCategoryId { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal? MinimumQuantity { get; set; }
        public string UnitType { get; set; }
        public decimal UnitPrice { get; set; }

        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? ProductCode { get; set; }
        public string? CountryOfOrigin { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? Depth { get; set; }

        public virtual PartCategory PartCategory { get; set; }
        public virtual ICollection<PartTransaction> PartTransactions { get; set; }
    }
}