using AutoMapper;
using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.BLL.Areas.Shared
{
    public class PartCategoryProfile : Profile
    {
        public PartCategoryProfile()
        {
            CreateMap<Margin, MarginEntity>()
                .ReverseMap();

            CreateMap<OperationalDocument, OperationalDocumentEntity>()
                .ReverseMap();

            CreateMap<Part, PartEntity>()
                .ReverseMap();

            CreateMap<PartCategory, PartCategoryEntity>()
                .ReverseMap();

            CreateMap<PartTransaction, PartTransactionEntity>()
                .ReverseMap();

            CreateMap<PartCategory, PartCategoryStructure>()
                .ForMember(x => x.SiblingCategories, opt => opt.Ignore());
        }
    }
}