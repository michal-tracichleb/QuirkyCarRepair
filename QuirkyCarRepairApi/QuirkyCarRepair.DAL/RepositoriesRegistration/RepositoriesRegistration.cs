using Microsoft.Extensions.DependencyInjection;
using QuirkyCarRepair.DAL.Areas.CarService.Interfaces;
using QuirkyCarRepair.DAL.Areas.CarService.Repositories;
using QuirkyCarRepair.DAL.Areas.Identity.Interfaces;
using QuirkyCarRepair.DAL.Areas.Identity.Repositories;
using QuirkyCarRepair.DAL.Areas.Shared.Interfaces;
using QuirkyCarRepair.DAL.Areas.Shared.Repositories;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Repositories;

namespace QuirkyCarRepair.DAL.RepositoriesRegistration
{
    public static class RepositoriesRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            #region Identity

            services.AddScoped<IAccountRepostiory, AccountRepostiory>();

            #endregion Identity

            #region Shared

            services.AddScoped<IOrderOwnerRepository, OrderOwnerRepository>();
            services.AddScoped<IMarginRepository, MarginRepository>();

            #endregion Shared

            #region CarService

            services.AddScoped<IMainCategoryServiceRepository, MainCategoryServiceRepository>();
            services.AddScoped<IServiceOfferRepository, ServiceOfferRepository>();
            services.AddScoped<IServiceOrderRepository, ServiceOrderRepository>();
            services.AddScoped<IServiceOrderStatusRepository, ServiceOrderStatusRepository>();
            services.AddScoped<IServiceTransactionRepository, ServiceTransactionRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();

            #endregion CarService

            #region WarehouseManagement

            services.AddScoped<IOperationalDocumentRepository, OperationalDocumentRepository>();
            services.AddScoped<IPartRepository, PartRepository>();
            services.AddScoped<IPartCategoryRepository, PartCategoryRepository>();
            services.AddScoped<IPartTransactionRepository, PartTransactionRepository>();
            services.AddScoped<ITransactionStatusRepository, TransactionStatusRepository>();

            #endregion WarehouseManagement
        }
    }
}