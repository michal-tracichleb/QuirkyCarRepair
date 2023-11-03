using Microsoft.AspNetCore.Mvc;
using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;
using QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces;

namespace QuirkyCarRepair.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        [Route("GetPrimaryCategories")]
        public List<PartCategoryEntity> GetPrimaryCategories()
        {
            return _warehouseService.GetPrimaryCategories();
        }

        [HttpGet]
        [Route("GetPartCategoryStructure")]
        public PartCategoryStructure GetPartCategoryStructure(int id)
        {
            return _warehouseService.GetPartCategoryStructure(id);
        }
    }
}