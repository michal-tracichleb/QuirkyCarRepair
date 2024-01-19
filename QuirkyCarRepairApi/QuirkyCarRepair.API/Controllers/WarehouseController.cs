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
            return Ok(_warehouseService.GetPrimaryCategories());
        }

        [HttpGet]
        [Route("GetPartCategoryStructure")]
        public IActionResult GetPartCategoryStructure(int id)
        {
            return Ok(_warehouseService.GetPartCategoryStructure(id));
        }

        [HttpPost]
        [Route("GetPartsPage")]
        public IActionResult GetPartsPage([FromBody] GetPartsPageDTO getPartsPageDTO)
        {
            return Ok(_warehouseService.GetPartsPage(getPartsPageDTO));
        }

        [HttpPost]
        [Route("DeliveryParts")]
        [Authorize(Roles = "Admin,Storekeeper")]
        public IActionResult DeliveryParts([FromBody] List<PartDTO> deliveryPartsDTO)
        {
            _warehouseService.DeliveryParts(deliveryPartsDTO);
            return Ok();
        }

        [HttpPost]
        [Route("OrderParts")]
        [Authorize]
        public IActionResult OrderParts([FromBody] OrderDTO orderDTO)
        {
            _warehouseService.OrderParts(orderDTO);
            return Ok();
        }

        [HttpPost]
        [Route("GetOrdersPage")]
        [Authorize]
        public IActionResult GetOrdersPage([FromBody] GetOrdersPageDTO getOrdersPageDTO)
        {
            return Ok(_warehouseService.GetOrdersPage(getOrdersPageDTO));
        }

        [HttpGet]
        [Route("CancelOrder")]
        [Authorize(Roles = "Admin,Storekeeper")]
        public IActionResult CancelOrder(int id)
        {
            _warehouseService.CancelOrder(id);
            return Ok();
        }

        [HttpGet]
        [Route("DetailsOrder")]
        [Authorize]
        public IActionResult DetailsOrder(int id)
        {
            return Ok(_warehouseService.DetailsOrder(id));
        }

        [HttpGet]
        [Route("ArrangeOrder")]
        [Authorize(Roles = "Admin,Storekeeper")]
        public IActionResult ArrangeOrder(int id)
        {
            return Ok(_warehouseService.ArrangeOrder(id));
        }

        [HttpGet]
        [Route("ReadyForPickup")]
        [Authorize(Roles = "Admin,Storekeeper")]
        public IActionResult ReadyForPickup(int id)
        {
            return Ok(_warehouseService.ReadyForPickup(id));
        }

        [HttpGet]
        [Route("OrderCompleted")]
        [Authorize(Roles = "Admin,Storekeeper")]
        public IActionResult OrderCompleted(int id)
        {
            return Ok(_warehouseService.OrderCompleted(id));
        }

        //[HttpPost]
        //[Route("")]
        //[Authorize(Roles = "Admin,Storekeeper")]
        //public IActionResult OrderCompleted([FromBody] )
        //{
        //    try
        //    {
        //        return Ok(_warehouseService.OrderCompleted());
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}