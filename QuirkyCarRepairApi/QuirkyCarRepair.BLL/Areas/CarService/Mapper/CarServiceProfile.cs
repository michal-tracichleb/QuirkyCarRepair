using AutoMapper;
using QuirkyCarRepair.BLL.Areas.CarService.DTO;
using QuirkyCarRepair.BLL.Areas.CarService.Entities;
using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Shared.Models;

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

            CreateMap<Vehicle, VehicleDataDTO>();
            CreateMap<OrderOwner, OrderOwnerDTO>();
            CreateMap<ServiceOrder, ServiceOrderDTO>()
                .ForMember(dest => dest.ServiceOrderId, opt => opt.MapFrom(src =>
                    src.Id))
                .ForMember(dest => dest.DocumentNumber, opt => opt.MapFrom(src =>
                    src.OrderNumber))
                .ForMember(dest => dest.UserData, opt => opt.MapFrom(src =>
                    src.OrderOwner))
                .ForMember(dest => dest.VehicleData, opt => opt.MapFrom(src =>
                    src.Vehicle))
                .ForMember(dest => dest.StatusStartDate, opt => opt.MapFrom(src =>
                    src.ServiceOrderStatuses.FirstOrDefault().StartDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>
                    src.ServiceOrderStatuses.FirstOrDefault().Status))
                .ForMember(dest => dest.OrderDescription, opt => opt.MapFrom(src =>
                    src.ServiceOrderStatuses.FirstOrDefault().Description));
        }
    }
}