using QuirkyCarRepair.DAL.Areas.Shared.Enums;

namespace QuirkyCarRepair.BLL.Areas.Warehouse.DTO
{
    public class GetOrdersPageDTO
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; }

        public List<TransactionType>? TransactionTypes { get; set; }
        public List<TransactionState>? TransactionStates { get; set; }
    }
}