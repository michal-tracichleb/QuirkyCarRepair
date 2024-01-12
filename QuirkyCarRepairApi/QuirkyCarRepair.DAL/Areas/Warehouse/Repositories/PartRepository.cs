using QuirkyCarRepair.DAL.Areas.Shared;
using QuirkyCarRepair.DAL.Areas.Shared.Enums;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;
using System.Linq.Expressions;

namespace QuirkyCarRepair.DAL.Areas.Warehouse.Repositories
{
    internal class PartRepository : Repository<Part>, IPartRepository
    {
        public PartRepository(QuirkyCarRepairContext context) : base(context)
        {
        }

        public IQueryable<Part> GetPartsByCategories(List<int> categoryIds, SortDirection sortDirection, string? searchPhrase, string? sortBy)
        {
            var result = _context.Parts
            .Where(x => categoryIds.Contains(x.PartCategoryId)
                && (string.IsNullOrEmpty(searchPhrase)
                || (x.Name.ToLower().Contains(searchPhrase.ToLower())
                || x.Description.ToLower().Contains(searchPhrase.ToLower()))))
                .OrderBy(x => x.Id);

            if (!string.IsNullOrEmpty(sortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<Part, object>>>
                {
                    { nameof(Part.Name), x => x.Name },
                    { nameof(Part.Quantity), x => x.Quantity },
                    { nameof(Part.UnitPrice), x => x.UnitPrice },
                };

                var selectedColumn = columnsSelectors[sortBy];

                result = sortDirection == SortDirection.ASC
                    ? result.OrderBy(selectedColumn)
                    : result.OrderByDescending(selectedColumn);
            }
            else
            {
                result = sortDirection == SortDirection.ASC
                    ? result.OrderBy(x => x.Id)
                    : result.OrderByDescending(x => x.Id);
            }

            return result;
        }
    }
}