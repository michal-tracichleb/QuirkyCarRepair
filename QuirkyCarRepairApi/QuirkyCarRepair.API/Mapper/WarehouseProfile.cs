using AutoMapper;
using QuirkyCarRepair.API.DTO.Warehouse;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;

namespace QuirkyCarRepair.API.Mapper
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<MarginEntity, MarginDTO>()
                .ReverseMap();

            CreateMap<OperationalDocumentEntity, OperationalDocumentDTO>()
                .ReverseMap();

            CreateMap<PartEntity, PartDTO>()
                .ReverseMap();

            CreateMap<PartCategoryEntity, PartCategoryDTO>()
                .ReverseMap();

            CreateMap<PartTransactionEntity, PartTransactionDTO>()
                .ReverseMap();
        }
    }
}