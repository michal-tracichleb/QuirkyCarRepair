using QuirkyCarRepair.BLL.Areas.Shared;
using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;

namespace QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces
{
    public interface IWarehouseService
    {
        public List<PartCategoryEntity> GetPrimaryCategories();

        public PartCategoryStructureDTO GetPartCategoryStructure(int id);

        public PageList<PartEntity> GetPartsPage(GetPartsPageDTO getPartsPageDTO);
    }
}