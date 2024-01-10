using AutoMapper;
using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;
using QuirkyCarRepair.DAL.Areas.Shared.Models;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.BLL.Areas.Shared
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
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

            CreateMap<PartCategory, PartCategoryStructureDTO>()
                .ForMember(x => x.SiblingCategories, opt => opt.Ignore());

            CreateMap<OperationalDocument, OperationalDocumentDTO>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src =>
                    src.TransactionStatuses.FirstOrDefault().StartDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>
                    src.TransactionStatuses.FirstOrDefault().Status))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src =>
                    src.TransactionStatuses.FirstOrDefault().Description));
        }
    }
}