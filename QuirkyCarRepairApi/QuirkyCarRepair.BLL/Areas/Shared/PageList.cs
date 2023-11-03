namespace QuirkyCarRepair.BLL.Areas.Shared
{
    public class PageList<T> where T : class
    {
        public int CurrentPage { get; set; }

        public int PageCount { get; set; }

        public int PageSize { get; set; }

        public int ItemCount { get; set; }

        public List<T> Items { get; set; }
    }
}