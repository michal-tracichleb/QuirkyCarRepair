using AutoMapper;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.BLL.Areas.Shared
{
    public class PartCategoryProfile : Profile
    {
        public PartCategoryProfile()
        {
            CreateMap<PartCategory, PartCategoryEntity>()
                .ReverseMap();

            CreateMap<Part, PartEntity>()
                .ReverseMap();

            CreateMap<Margin, MarginEntity>()
                .ReverseMap();
        }
    }
}