using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;
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
        public IActionResult GetPrimaryCategories()
        {
            try
            {
                return Ok(_warehouseService.GetPrimaryCategories());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetPartCategoryStructure")]
        public IActionResult GetPartCategoryStructure(int id)
        {
            try
            {
                return Ok(_warehouseService.GetPartCategoryStructure(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("GetPartsPage")]
        public IActionResult GetPartsPage([FromBody] GetPartsPageDTO getPartsPageDTO)
        {
            try
            {
                return Ok(_warehouseService.GetPartsPage(getPartsPageDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DeliveryParts")]
        [Authorize(Roles = "Admin,Storekeeper")]
        public IActionResult DeliveryParts([FromBody] List<DeliveryPartsDTO> deliveryPartsDTO)
        {
            try
            {
                _warehouseService.DeliveryParts(deliveryPartsDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("OrderParts")]
        [Authorize]
        public IActionResult OrderParts([FromBody] OrderDTO orderDTO)
        {
            try
            {
                _warehouseService.OrderParts(orderDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("GetOrdersPage")]
        [Authorize(Roles = "Admin,Storekeeper")]
        public IActionResult GetOrdersPage([FromBody] GetOrdersPageDTO getOrdersPageDTO)
        {
            try
            {
                return Ok(_warehouseService.GetOrdersPage(getOrdersPageDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("CancelOrder")]
        [Authorize(Roles = "Admin,Storekeeper")]
        public IActionResult CancelOrder(int id)
        {
            try
            {
                _warehouseService.CancelOrder(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}