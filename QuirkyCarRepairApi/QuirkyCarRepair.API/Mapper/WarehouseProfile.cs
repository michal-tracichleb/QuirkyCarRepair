using AutoMapper;
using QuirkyCarRepair.API.DTO.Warehouse;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;

namespace QuirkyCarRepair.API.Mapper
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<PartCategoryEntity, PartCategoryDTO>()
                .ReverseMap();

            CreateMap<PartEntity, PartDTO>()
                .ReverseMap();

            CreateMap<MarginEntity, MarginDTO>()
                .ReverseMap();
        }
    }
}