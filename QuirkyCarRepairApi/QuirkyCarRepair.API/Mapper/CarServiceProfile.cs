using AutoMapper;
using QuirkyCarRepair.API.DTO.CarService;
using QuirkyCarRepair.BLL.Areas.CarService.Entities;

namespace QuirkyCarRepair.API.Mapper
{
    public class CarServiceProfile : Profile
    {
        public CarServiceProfile()
        {
            CreateMap<ServiceOrderEntity, ServiceOrderDTO>()
                .ReverseMap();
        }
    }
}