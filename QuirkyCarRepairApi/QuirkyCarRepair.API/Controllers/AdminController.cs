using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuirkyCarRepair.API.DTO.Warehouse;
using QuirkyCarRepair.BLL.Areas.Admin.Interfaces;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;
using QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces;

namespace QuirkyCarRepair.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMarginService _marginService;
        private readonly IAdminService _adminService;

        public AdminController(IMapper mapper,
            IMarginService marginService,
            IAdminService adminService)
        {
            _mapper = mapper;
            _marginService = marginService;
            _adminService = adminService;
        }

        // GET: api/Admin/Margin/GetAll
        [HttpGet]
        [Route("Margin/GetAll")]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<MarginDTO>>(_marginService.GetAll()));
        }

        // GET api/Admin/Margin/Get?id=1
        [HttpGet]
        [Route("Margin/Get")]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<MarginDTO>(_marginService.Get(id)));
        }

        // POST api/Admin/Margin/Post
        [HttpPost]
        [Route("Margin/Post")]
        public IActionResult Post([FromBody] MarginDTO model)
        {
            var marginEntity = _mapper.Map<MarginEntity>(model);
            var newMargin = _mapper.Map<MarginDTO>(_marginService.Creat(marginEntity));

            return CreatedAtAction(nameof(Get), newMargin.Id, newMargin);
        }

        // PUT api/Admin/Margin/Update?id=1
        [HttpPut]
        [Route("Margin/Update")]
        public void Update(int id, [FromBody] MarginDTO model)
        {
            _marginService.Update(id, _mapper.Map<MarginEntity>(model));
        }

        // DELETE api/Admin/Margin/Delete?id=1
        [HttpDelete]
        [Route("Margin/Delete")]
        public void Delete(int id)
        {
            _marginService.Delete(id);
        }

        // api/Admin/Margin/AssignToPartCategory?categoryId=5&marginId=1
        [HttpGet]
        [Route("Margin/AssignToPartCategory")]
        public IActionResult AssignToPartCategory(int marginId, int categoryId)
        {
            _adminService.AssignMarginToPartCategory(marginId, categoryId);
            return Ok();
        }

        // api/Admin/Margin/AssignToMainCategoryService?categoryId=5&mainCategoryServiceId=1
        [HttpGet]
        [Route("Margin/AssignToMainCategoryService")]
        public IActionResult AssignToMainCategoryService(int marginId, int mainCategoryServiceId)
        {
            _adminService.AssignMarginToMainCategoryService(marginId, mainCategoryServiceId);
            return Ok();
        }
    }
}