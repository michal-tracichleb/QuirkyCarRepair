using QuirkyCarRepair.BLL.Areas.Shared;

namespace QuirkyCarRepair.BLL.Extensions
{
    public static class IQueryableExtension
    {
        public static PageList<T> GetPagedList<T>(this IQueryable<T> queryable, int page, int pageSize)
            where T : class
        {
            var result = new PageList<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.ItemCount = queryable.Count();

            var pageCount = (double)result.ItemCount / pageSize;

            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;

            result.Items = queryable.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}