using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuirkyCarRepair.BLL.Areas.CarService.DTO;
using QuirkyCarRepair.BLL.Areas.CarService.Interfaces;
using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;

namespace QuirkyCarRepair.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarServiceController : ControllerBase
    {
        private readonly ICarServiceService _carServiceService;

        public CarServiceController(ICarServiceService carServiceService)
        {
            _carServiceService = carServiceService;
        }

        [HttpPost]
        [Route("CreateServiceOrder")]
        [Authorize]
        public IActionResult CreateServiceOrder([FromBody] CreateServiceOrderDTO createServiceOrderDTO)
        {
            var result = _carServiceService.NewOrderService(createServiceOrderDTO);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetServiceOrderPage")]
        [Authorize(Roles = "Admin,Mechanic")]
        public IActionResult GetServiceOrderPage([FromBody] GetServiceOrderPage getServiceOrderPage)
        {
            var result = _carServiceService.GetOrdersPage(getServiceOrderPage);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetDetailsServiceOrder")]
        [Authorize]
        public IActionResult GetDetailsServiceOrder(int id)
        {
            var result = _carServiceService.GetDetailsServiceOrder(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllMainCategoryService")]
        [Authorize(Roles = "Admin,Mechanic")]
        public IActionResult GetAllMainCategoryService()
        {
            var result = _carServiceService.GetAllMainCategoryService();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetServiceOfferByMainCategory")]
        [Authorize(Roles = "Admin,Mechanic")]
        public IActionResult GetServiceOfferByMainCategory(int mainCategoryId)
        {
            var result = _carServiceService.GetServiceOfferByMainCategory(mainCategoryId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllServiceOffer")]
        [Authorize(Roles = "Admin,Mechanic")]
        public IActionResult GetAllServiceOffer()
        {
            var result = _carServiceService.GetAllServiceOffer();
            return Ok(result);
        }
    }
}