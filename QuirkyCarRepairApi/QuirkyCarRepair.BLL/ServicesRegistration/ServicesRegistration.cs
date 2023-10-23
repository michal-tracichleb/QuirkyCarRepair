using Microsoft.Extensions.DependencyInjection;
using QuirkyCarRepair.BLL.Areas.CarService.Interfaces;
using QuirkyCarRepair.BLL.Areas.CarService.Services;
using QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.BLL.Areas.Warehouse.Services;

namespace QuirkyCarRepair.BLL.ServicesRegistration
{
    public static class ServicesRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            #region CarService

            services.AddScoped<IServiceOrderService, ServiceOrderService>();

            #endregion CarService

            #region WarehouseManagement

            services.AddScoped<IPartCategoryService, PartCategoryService>();

            #endregion WarehouseManagement
        }
    }
}