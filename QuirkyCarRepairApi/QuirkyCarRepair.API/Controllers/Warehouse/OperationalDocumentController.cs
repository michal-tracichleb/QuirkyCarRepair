﻿using AutoMapper;
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
    public class OperationalDocumentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOperationalDocumentService _operationalDocumentService;

        public OperationalDocumentController(IMapper mapper,
            IOperationalDocumentService operationalDocumentService)
        {
            _mapper = mapper;
            _operationalDocumentService = operationalDocumentService;
        }

        // GET: api/Warehouse/<OperationalDocumentController>
        [HttpGet]
        public IEnumerable<OperationalDocumentDTO> Get()
        {
            return _mapper.Map<List<OperationalDocumentDTO>>(_operationalDocumentService.GetAll());
        }

        // GET api/Warehouse/<OperationalDocumentController>/5
        [HttpGet("{id}")]
        public OperationalDocumentDTO Get(int id)
        {
            return _mapper.Map<OperationalDocumentDTO>(_operationalDocumentService.Get(id));
        }

        // POST api/Warehouse/<OperationalDocumentController>
        [HttpPost]
        public ActionResult<OperationalDocumentDTO> Post([FromBody] OperationalDocumentDTO model)
        {
            var operationalDocumentEntity = _mapper.Map<OperationalDocumentEntity>(model);
            var newOperationalDocument = _mapper.Map<OperationalDocumentDTO>(_operationalDocumentService.Creat(operationalDocumentEntity));

            return CreatedAtAction(nameof(Get), newOperationalDocument.Id, newOperationalDocument);
        }

        // PUT api/Warehouse/<OperationalDocumentController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] OperationalDocumentDTO model)
        {
            _operationalDocumentService.Update(id, _mapper.Map<OperationalDocumentEntity>(model));
        }

        // DELETE api/Warehouse/<OperationalDocumentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _operationalDocumentService.Delete(id);
        }
    }
}