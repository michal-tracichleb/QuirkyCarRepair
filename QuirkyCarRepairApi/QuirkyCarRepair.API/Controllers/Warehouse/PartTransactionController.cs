using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuirkyCarRepair.API.DTO.Warehouse;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;
using QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces;

namespace QuirkyCarRepair.API.Controllers.Warehouse
{
    [Route("api/Warehouse/[controller]")]
    [ApiController]
    public class PartTransactionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPartTransactionService _partTransactionService;

        public PartTransactionController(IMapper mapper,
            IPartTransactionService partTransactionService)
        {
            _mapper = mapper;
            _partTransactionService = partTransactionService;
        }

        // GET: api/<PartTransactionController>
        [HttpGet]
        public IEnumerable<PartTransactionDTO> Get()
        {
            return _mapper.Map<List<PartTransactionDTO>>(_partTransactionService.GetAll());
        }

        // GET api/<PartTransactionController>/5
        [HttpGet("{id}")]
        public PartTransactionDTO Get(int id)
        {
            return _mapper.Map<PartTransactionDTO>(_partTransactionService.Get(id));
        }

        // POST api/<PartTransactionController>
        [HttpPost]
        public ActionResult<PartTransactionDTO> Post([FromBody] PartTransactionDTO model)
        {
            var partTransactionEntity = _mapper.Map<PartTransactionEntity>(model);
            var newPartTransaction = _mapper.Map<PartTransactionDTO>(_partTransactionService.Creat(partTransactionEntity));

            return CreatedAtAction(nameof(Get), newPartTransaction.Id, newPartTransaction);
        }

        // PUT api/<PartTransactionController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] PartTransactionDTO model)
        {
            _partTransactionService.Update(id, _mapper.Map<PartTransactionEntity>(model));
        }

        // DELETE api/<PartTransactionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _partTransactionService.Delete(id);
        }
    }
}