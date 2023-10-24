﻿namespace QuirkyCarRepair.BLL.Areas.Warehouse.Entities
{
    public class PartEntity
    {
        public int Id { get; set; }
        public int PartCategoryId { get; set; }
        public int? MarginId { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal? MinimumQuantity { get; set; }
        public string UnitType { get; set; }
        public decimal UnitPrice { get; set; }
    }
}