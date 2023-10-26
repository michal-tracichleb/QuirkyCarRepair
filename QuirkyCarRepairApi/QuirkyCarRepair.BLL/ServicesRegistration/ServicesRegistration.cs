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
            services.AddScoped<IServiceOrderStatusService, ServiceOrderStatusService>();
            services.AddScoped<IVehicleService, VehicleService>();

            #endregion CarService

            #region WarehouseManagement

            services.AddScoped<IMarginService, MarginService>();
            services.AddScoped<IOperationalDocumentService, OperationalDocumentService>();
            services.AddScoped<IPartService, PartService>();
            services.AddScoped<IPartCategoryService, PartCategoryService>();
            services.AddScoped<IPartTransactionService, PartTransactionService>();

            #endregion WarehouseManagement
        }
    }
}