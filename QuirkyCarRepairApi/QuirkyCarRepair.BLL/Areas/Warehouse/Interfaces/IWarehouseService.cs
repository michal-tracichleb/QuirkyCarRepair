using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;

namespace QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces
{
    public interface IWarehouseService
    {
        public PartCategoryStructure GetPartCategoryStructure(int id);
    }
}