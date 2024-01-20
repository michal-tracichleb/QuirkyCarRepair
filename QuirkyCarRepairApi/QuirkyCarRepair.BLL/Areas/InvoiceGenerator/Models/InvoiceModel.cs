namespace QuirkyCarRepair.BLL.Areas.InvoiceGenerator.Models
{
    public class InvoiceModel
    {
        public string InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }

        public Address SellerAddress { get; set; }
        public Address CustomerAddress { get; set; }

        public List<OrderThing> Items { get; set; }
    }
}