using AutoMapper;
using QuirkyCarRepair.BLL.Areas.CarService.Entities;
using QuirkyCarRepair.DAL.Areas.CarService.Models;

namespace QuirkyCarRepair.BLL.Areas.Shared
{
    public class ServiceOrderProfile : Profile
    {
        public ServiceOrderProfile()
        {
            CreateMap<ServiceOrder, ServiceOrderEntity>()
                .ReverseMap();

            CreateMap<ServiceOrderStatus, ServiceOrderStatusEntity>()
                .ReverseMap();

            CreateMap<Vehicle, VehicleEntity>()
                .ReverseMap();
        }
    }
}