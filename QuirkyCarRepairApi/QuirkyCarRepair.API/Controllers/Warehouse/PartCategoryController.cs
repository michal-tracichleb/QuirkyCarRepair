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
    public class PartCategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPartCategoryService _partCategoryService;

        public PartCategoryController(IMapper mapper,
            IPartCategoryService partCategoryService)
        {
            _mapper = mapper;
            _partCategoryService = partCategoryService;
        }

        // GET: api/<PartCategoryController>
        [HttpGet]
        public IEnumerable<PartCategoryDTO> Get()
        {
            return _mapper.Map<List<PartCategoryDTO>>(_partCategoryService.GetAll());
        }

        // GET api/<PartCategoryController>/5
        [HttpGet("{id}")]
        public PartCategoryDTO Get(int id)
        {
            return _mapper.Map<PartCategoryDTO>(_partCategoryService.Get(id));
        }

        // POST api/<PartCategoryController>
        [HttpPost]
        [Authorize(Roles = "Admin, Storekeeper")]
        public ActionResult<PartCategoryDTO> Post([FromBody] PartCategoryDTO model)
        {
            var partCategoryEntity = _mapper.Map<PartCategoryEntity>(model);
            var newPartCategory = _mapper.Map<PartCategoryDTO>(_partCategoryService.Creat(partCategoryEntity));

            return CreatedAtAction(nameof(Get), newPartCategory.Id, newPartCategory);
        }

        // PUT api/<PartCategoryController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Storekeeper")]
        public void Update(int id, [FromBody] PartCategoryDTO model)
        {
            _partCategoryService.Update(id, _mapper.Map<PartCategoryEntity>(model));
        }

        // DELETE api/<PartCategoryController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Storekeeper")]
        public void Delete(int id)
        {
            _partCategoryService.Delete(id);
        }
    }
}