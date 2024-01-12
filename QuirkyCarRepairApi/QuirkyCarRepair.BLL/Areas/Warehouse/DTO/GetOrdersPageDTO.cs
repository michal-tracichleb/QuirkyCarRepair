using QuirkyCarRepair.DAL.Areas.Shared.Enums;

namespace QuirkyCarRepair.BLL.Areas.Warehouse.DTO
{
    public class GetOrdersPageDTO
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; }

        public List<OrderType>? OrderTypes { get; set; }
        public List<OrderStatus>? OrderStates { get; set; }
    }
}