using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuirkyCarRepair.API.DTO.CarService;
using QuirkyCarRepair.BLL.Areas.CarService.Entities;
using QuirkyCarRepair.BLL.Areas.CarService.Interfaces;

namespace QuirkyCarRepair.API.Controllers.ServiceOrderStatus
{
    [Route("api/CarService/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Mechanic")]
    public class ServiceOrderStatusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServiceOrderStatusService _serviceOrderStatusService;

        public ServiceOrderStatusController(IMapper mapper,
            IServiceOrderStatusService serviceOrderStatusService)
        {
            _mapper = mapper;
            _serviceOrderStatusService = serviceOrderStatusService;
        }

        // GET: api/<ServiceOrderStatusController>
        [HttpGet]
        public IEnumerable<ServiceOrderStatusDTO> Get()
        {
            return _mapper.Map<List<ServiceOrderStatusDTO>>(_serviceOrderStatusService.GetAll());
        }

        // GET api/<ServiceOrderStatusController>/5
        [HttpGet("{id}")]
        public ServiceOrderStatusDTO Get(int id)
        {
            return _mapper.Map<ServiceOrderStatusDTO>(_serviceOrderStatusService.Get(id));
        }

        // POST api/<ServiceOrderStatusController>
        [HttpPost]
        public ActionResult<ServiceOrderStatusDTO> Post([FromBody] ServiceOrderStatusDTO model)
        {
            var serviceOrderStatusEntity = _mapper.Map<ServiceOrderStatusEntity>(model);
            var newServiceOrderStatus = _mapper.Map<ServiceOrderStatusDTO>(_serviceOrderStatusService.Creat(serviceOrderStatusEntity));

            return CreatedAtAction(nameof(Get), newServiceOrderStatus.Id, newServiceOrderStatus);
        }

        // PUT api/<ServiceOrderStatusController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] ServiceOrderStatusDTO model)
        {
            _serviceOrderStatusService.Update(id, _mapper.Map<ServiceOrderStatusEntity>(model));
        }

        // DELETE api/<ServiceOrderStatusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _serviceOrderStatusService.Delete(id);
        }
    }
}