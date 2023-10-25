using AutoMapper;
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
        }
    }
}