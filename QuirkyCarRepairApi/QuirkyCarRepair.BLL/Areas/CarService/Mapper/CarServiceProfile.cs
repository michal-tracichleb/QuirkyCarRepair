using AutoMapper;
using QuirkyCarRepair.BLL.Areas.CarService.Entities;
using QuirkyCarRepair.DAL.Areas.CarService.Models;

namespace QuirkyCarRepair.BLL.Areas.Shared
{
    public class CarServiceProfile : Profile
    {
        public CarServiceProfile()
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