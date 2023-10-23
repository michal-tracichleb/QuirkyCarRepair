using AutoMapper;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entites;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.BLL.Areas.Shared
{
    public class PartCategoryProfile : Profile
    {
        public PartCategoryProfile()
        {
            CreateMap<PartCategory, PartCategoryEntity>()
                .ReverseMap();
        }
    }
}