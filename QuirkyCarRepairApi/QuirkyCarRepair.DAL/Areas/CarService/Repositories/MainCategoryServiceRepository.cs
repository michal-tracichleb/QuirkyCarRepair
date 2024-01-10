using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Shared;

namespace QuirkyCarRepair.DAL.Areas.CarService.Repositories
{
    internal class MainCategoryServiceRepository : Repository<MainCategoryService>, IMainCategoryServiceRepository
    {
        public MainCategoryServiceRepository(QuirkyCarRepairContext context) : base(context)
        {
        }
    }
}