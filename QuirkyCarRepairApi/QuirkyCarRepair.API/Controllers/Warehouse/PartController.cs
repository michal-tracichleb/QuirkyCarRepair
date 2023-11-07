using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuirkyCarRepair.API.DTO.Warehouse;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;
using QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces;

namespace QuirkyCarRepair.API.Controllers.Warehouse
{
    [Route("api/Warehouse/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPartService _partService;

        public PartController(IMapper mapper,
            IPartService partService)
        {
            _mapper = mapper;
            _partService = partService;
        }

        // GET: api/Warehouse/<PartController>
        [HttpGet]
        public IEnumerable<PartDTO> Get()
        {
            return _mapper.Map<List<PartDTO>>(_partService.GetAll());
        }

        // GET api/Warehouse/<PartController>/5
        [HttpGet("{id}")]
        public PartDTO Get(int id)
        {
            return _mapper.Map<PartDTO>(_partService.Get(id));
        }

        // POST api/Warehouse/<PartController>
        [HttpPost]
        public ActionResult<PartDTO> Post([FromBody] PartDTO model)
        {
            var partEntity = _mapper.Map<PartEntity>(model);
            var newPart = _mapper.Map<PartDTO>(_partService.Creat(partEntity));

            return CreatedAtAction(nameof(Get), newPart.Id, newPart);
        }

        // PUT api/Warehouse/<PartController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] PartDTO model)
        {
            _partService.Update(id, _mapper.Map<PartEntity>(model));
        }

        // DELETE api/Warehouse/<PartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _partService.Delete(id);
        }
    }
}