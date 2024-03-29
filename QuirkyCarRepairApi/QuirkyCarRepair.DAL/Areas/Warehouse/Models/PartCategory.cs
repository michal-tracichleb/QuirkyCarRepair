﻿using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Shared.Models;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Models
{
    public class PartCategory : IModelBase
    {
        public PartCategory()
        {
            Subcategories = new HashSet<PartCategory>();
            Parts = new HashSet<Part>();
        }

        public int Id { get; set; }
        public int? ParentCategoryId { get; set; }
        public int? MarginId { get; set; }

        public string Name { get; set; }

        public virtual Margin Margin { get; set; }
        public virtual PartCategory ParentCategory { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        public virtual ICollection<PartCategory> Subcategories { get; set; }
    }
}