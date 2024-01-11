using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}