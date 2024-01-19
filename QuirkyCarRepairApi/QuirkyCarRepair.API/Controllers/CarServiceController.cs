using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuirkyCarRepair.BLL.Areas.CarService.DTO;
using QuirkyCarRepair.BLL.Areas.CarService.Interfaces;
using QuirkyCarRepair.BLL.Areas.Warehouse.DTO;
using QuirkyCarRepair.DAL.Areas.Shared.Enums;

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

        [HttpGet]
        [Route("ServiceOrderCanceled")]
        [Authorize(Roles = "Admin,Mechanic,User")]
        public IActionResult ServiceOrderCanceled(int id, string? description)
        {
            var result = _carServiceService.ChangeStatus(id, description, OrderStatus.Canceled);
            return Ok(result);
        }

        [HttpGet]
        [Route("ServiceOrderAcceptedDate")]
        [Authorize(Roles = "Admin,Mechanic")]
        public IActionResult ServiceOrderAcceptedDate(int id, string? description)
        {
            var result = _carServiceService.ChangeStatus(id, description, OrderStatus.AcceptedDate);
            return Ok(result);
        }

        [HttpGet]
        [Route("ServiceOrderRepairAnalysis")]
        [Authorize(Roles = "Admin,Mechanic")]
        public IActionResult ServiceOrderRepairAnalysis(int id, string? description)
        {
            var result = _carServiceService.ChangeStatus(id, description, OrderStatus.RepairAnalysis);
            return Ok(result);
        }

        [HttpGet]
        [Route("ServiceOrderPendingForClientAccepting")]
        [Authorize(Roles = "Admin,Mechanic")]
        public IActionResult ServiceOrderPendingForClientAccepting(int id, string? description)
        {
            var result = _carServiceService.ChangeStatus(id, description, OrderStatus.PendingForClientAccepting);
            return Ok(result);
        }

        [HttpGet]
        [Route("ServiceOrderAcceptedByClient")]
        [Authorize(Roles = "Admin,Mechanic,User")]
        public IActionResult ServiceOrderAcceptedByClient(int id, string? description)
        {
            var result = _carServiceService.ChangeStatus(id, description, OrderStatus.AcceptedByClient);
            return Ok(result);
        }

        [HttpGet]
        [Route("ServiceOrderCanceledByclient")]
        [Authorize(Roles = "Admin,Mechanic,User")]
        public IActionResult ServiceOrderCanceledByclient(int id, string? description)
        {
            var result = _carServiceService.ChangeStatus(id, description, OrderStatus.CanceledByclient);
            return Ok(result);
        }

        [HttpGet]
        [Route("ServiceOrderRepair")]
        [Authorize(Roles = "Admin,Mechanic")]
        public IActionResult ServiceOrderRepair(int id, string? description)
        {
            var result = _carServiceService.ChangeStatus(id, description, OrderStatus.Repair);
            return Ok(result);
        }

        [HttpGet]
        [Route("ServiceOrderReady")]
        [Authorize(Roles = "Admin,Mechanic")]
        public IActionResult ServiceOrderReady(int id, string? description)
        {
            var result = _carServiceService.ChangeStatus(id, description, OrderStatus.Ready);
            return Ok(result);
        }

        [HttpGet]
        [Route("ServiceOrderComplaint")]
        [Authorize(Roles = "Admin,Mechanic,User")]
        public IActionResult ServiceOrderComplaint(int id, string? description)
        {
            var result = _carServiceService.ChangeStatus(id, description, OrderStatus.Complaint);
            return Ok(result);
        }

        [HttpGet]
        [Route("AddServiceToOrder")]
        [Authorize(Roles = "Admin,Mechanic,User")]
        public IActionResult AddServiceToOrder([FromQuery] int serviceOrderId, [FromQuery] int serviceOfferId, [FromQuery] int numberOfServices)
        {
            var result = _carServiceService.AddServiceToOrder(serviceOrderId, serviceOfferId, numberOfServices);
            return Ok(result);
        }
    }
}