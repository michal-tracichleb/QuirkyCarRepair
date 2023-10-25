﻿namespace QuirkyCarRepair.DAL.Areas.Warehouse.Models
{
    public class Part
    {
        public Part()
        {
            PartTransactions = new HashSet<PartTransaction>();
        }

        public int Id { get; set; }
        public int PartCategoryId { get; set; }
        public int? MarginId { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal? MinimumQuantity { get; set; }
        public string UnitType { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual PartCategory PartCategory { get; set; }
        public virtual Margin Margin { get; set; }
        public virtual ICollection<PartTransaction> PartTransactions { get; set; }
    }
}