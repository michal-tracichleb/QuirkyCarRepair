using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuirkyCarRepair.API.DTO.Warehouse;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;
using QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces;

namespace QuirkyCarRepair.API.Controllers.Warehouse
{
    [Route("api/Warehouse/[controller]")]
    [ApiController]
    [Authorize]
    public class MarginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMarginService _marginService;

        public MarginController(IMapper mapper,
            IMarginService marginService)
        {
            _mapper = mapper;
            _marginService = marginService;
        }

        // GET: api/Warehouse/<MarginController>
        [HttpGet]
        public IEnumerable<MarginDTO> Get()
        {
            return _mapper.Map<List<MarginDTO>>(_marginService.GetAll());
        }

        // GET api/Warehouse/<MarginController>/5
        [HttpGet("{id}")]
        public MarginDTO Get(int id)
        {
            return _mapper.Map<MarginDTO>(_marginService.Get(id));
        }

        // POST api/Warehouse/<MarginController>
        [HttpPost]
        public ActionResult<MarginDTO> Post([FromBody] MarginDTO model)
        {
            var marginEntity = _mapper.Map<MarginEntity>(model);
            var newMargin = _mapper.Map<MarginDTO>(_marginService.Creat(marginEntity));

            return CreatedAtAction(nameof(Get), newMargin.Id, newMargin);
        }

        // PUT api/Warehouse/<MarginController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] MarginDTO model)
        {
            _marginService.Update(id, _mapper.Map<MarginEntity>(model));
        }

        // DELETE api/Warehouse/<MarginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _marginService.Delete(id);
        }
    }
}