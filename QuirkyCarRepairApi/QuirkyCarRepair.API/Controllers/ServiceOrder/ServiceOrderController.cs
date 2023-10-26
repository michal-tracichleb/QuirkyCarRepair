using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuirkyCarRepair.API.DTO.CarService;
using QuirkyCarRepair.BLL.Areas.CarService.Entities;
using QuirkyCarRepair.BLL.Areas.CarService.Interfaces;

namespace QuirkyCarRepair.API.Controllers.ServiceOrder
{
    [Route("api/CarService/[controller]")]
    [ApiController]
    [Authorize]
    public class ServiceOrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServiceOrderService _serviceOrderService;

        public ServiceOrderController(IMapper mapper,
            IServiceOrderService serviceOrderService)
        {
            _mapper = mapper;
            _serviceOrderService = serviceOrderService;
        }

        // GET: api/<ServiceOrderController>
        [HttpGet]
        public IEnumerable<ServiceOrderDTO> Get()
        {
            return _mapper.Map<List<ServiceOrderDTO>>(_serviceOrderService.GetAll());
        }

        // GET api/<ServiceOrderController>/5
        [HttpGet("{id}")]
        public ServiceOrderDTO Get(int id)
        {
            return _mapper.Map<ServiceOrderDTO>(_serviceOrderService.Get(id));
        }

        // POST api/<ServiceOrderController>
        [HttpPost]
        public ActionResult<ServiceOrderDTO> Post([FromBody] ServiceOrderDTO model)
        {
            var serviceOrderEntity = _mapper.Map<ServiceOrderEntity>(model);
            var newServiceOrder = _mapper.Map<ServiceOrderDTO>(_serviceOrderService.Creat(serviceOrderEntity));

            return CreatedAtAction(nameof(Get), newServiceOrder.Id, newServiceOrder);
        }

        // PUT api/<ServiceOrderController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] ServiceOrderDTO model)
        {
            _serviceOrderService.Update(id, _mapper.Map<ServiceOrderEntity>(model));
        }

        // DELETE api/<ServiceOrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _serviceOrderService.Delete(id);
        }
    }
}