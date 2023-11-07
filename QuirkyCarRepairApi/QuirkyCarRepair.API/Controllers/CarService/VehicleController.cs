using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuirkyCarRepair.API.DTO.CarService;
using QuirkyCarRepair.BLL.Areas.CarService.Entities;
using QuirkyCarRepair.BLL.Areas.CarService.Interfaces;

namespace QuirkyCarRepair.API.Controllers.CarService
{
    [Route("api/CarService/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVehicleService _vehicleService;

        public VehicleController(IMapper mapper,
            IVehicleService vehicleService)
        {
            _mapper = mapper;
            _vehicleService = vehicleService;
        }

        // GET: api/CarService/<VehicleController>
        [HttpGet]
        public IEnumerable<VehicleDTO> Get()
        {
            return _mapper.Map<List<VehicleDTO>>(_vehicleService.GetAll());
        }

        // GET api/CarService/<VehicleController>/5
        [HttpGet("{id}")]
        public VehicleDTO Get(int id)
        {
            return _mapper.Map<VehicleDTO>(_vehicleService.Get(id));
        }

        // POST api/CarService/<VehicleController>
        [HttpPost]
        public ActionResult<VehicleDTO> Post([FromBody] VehicleDTO model)
        {
            var vehicleEntity = _mapper.Map<VehicleEntity>(model);
            var newVehicle = _mapper.Map<VehicleDTO>(_vehicleService.Creat(vehicleEntity));

            return CreatedAtAction(nameof(Get), newVehicle.Id, newVehicle);
        }

        // PUT api/CarService/<VehicleController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] VehicleDTO model)
        {
            _vehicleService.Update(id, _mapper.Map<VehicleEntity>(model));
        }

        // DELETE api/CarService/<VehicleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _vehicleService.Delete(id);
        }
    }
}