using QuirkyCarRepair.DAL.Areas.Shared.Enums;

namespace QuirkyCarRepair.BLL.Areas.Warehouse.DTO
{
    public class GetPartsPageDTO
    {
        public string? SearchPhrase { get; set; }

        public int CategoryId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}