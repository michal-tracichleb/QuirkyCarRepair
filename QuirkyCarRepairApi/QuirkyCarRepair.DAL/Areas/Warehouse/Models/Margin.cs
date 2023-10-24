namespace QuirkyCarRepair.DAL.Areas.Warehouse.Models
{
    public class Margin
    {
        public Margin()
        {
            Parts = new HashSet<Part>();
        }

        public int Id { get; set; }

        public decimal Value { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}