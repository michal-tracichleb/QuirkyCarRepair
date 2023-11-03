using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;

namespace QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces
{
    public interface IWarehouseService
    {
        public List<PartCategoryEntity> GetPrimaryCategories();

        public PartCategoryStructure GetPartCategoryStructure(int id);
    }
}