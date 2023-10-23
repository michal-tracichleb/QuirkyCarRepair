using Microsoft.Extensions.DependencyInjection;
using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Repositories;

namespace QuirkyCarRepair.DAL.RepositoriesRegistration
{
    public static class RepositoriesRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            #region CarService

            services.AddScoped<IServiceOrderRepository, ServiceOrderRepository>();

            #endregion CarService

            #region WarehouseManagement

            services.AddScoped<IPartCategoryRepository, PartCategoryRepository>();

            #endregion WarehouseManagement
        }
    }
}