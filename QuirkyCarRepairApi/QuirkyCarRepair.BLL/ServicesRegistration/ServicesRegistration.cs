using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using QuirkyCarRepair.BLL.Areas.CarService.Interfaces;
using QuirkyCarRepair.BLL.Areas.CarService.Services;
using QuirkyCarRepair.BLL.Areas.Identity.DTO;
using QuirkyCarRepair.BLL.Areas.Identity.Interfaces;
using QuirkyCarRepair.BLL.Areas.Identity.Services;
using QuirkyCarRepair.BLL.Areas.Identity.Validators;
using QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.BLL.Areas.Warehouse.Services;
using QuirkyCarRepair.DAL.Areas.Identity.Models;

namespace QuirkyCarRepair.BLL.ServicesRegistration
{
    public static class ServicesRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            #region Identity

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
            services.AddScoped<IUserContextService, UserContextService>();
            services.AddHttpContextAccessor();

            #endregion Identity

            #region CarService

            services.AddScoped<IServiceOrderService, ServiceOrderService>();
            services.AddScoped<IServiceOrderStatusService, ServiceOrderStatusService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<ICarServiceService, CarServiceService>();

            #endregion CarService

            #region WarehouseManagement

            services.AddScoped<IMarginService, MarginService>();
            services.AddScoped<IOperationalDocumentService, OperationalDocumentService>();
            services.AddScoped<IPartService, PartService>();
            services.AddScoped<IPartCategoryService, PartCategoryService>();
            services.AddScoped<IPartTransactionService, PartTransactionService>();
            services.AddScoped<IWarehouseService, WarehouseService>();

            #endregion WarehouseManagement
        }
    }
}