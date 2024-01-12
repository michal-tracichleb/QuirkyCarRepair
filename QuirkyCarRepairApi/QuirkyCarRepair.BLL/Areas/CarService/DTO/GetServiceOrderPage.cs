using QuirkyCarRepair.DAL.Areas.Shared.Enums;

namespace QuirkyCarRepair.BLL.Areas.CarService.DTO
{
    public class GetServiceOrderPage
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public bool AnyDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; }

        public List<OrderStatus>? OrderStates { get; set; }
    }
}