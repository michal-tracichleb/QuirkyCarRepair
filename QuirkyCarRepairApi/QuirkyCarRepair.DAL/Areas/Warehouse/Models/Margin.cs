using QuirkyCarRepair.DAL.Areas.Shared;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Models
{
    public class Margin : IModelBase
    {
        public Margin()
        {
            Parts = new HashSet<Part>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Value { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}