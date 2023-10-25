using AutoMapper;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;
using QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;
using QuirkyCarRepair.DAL.Exceptions;

namespace QuirkyCarRepair.BLL.Areas.Warehouse.Services
{
    internal class OperationalDocumentService : IOperationalDocumentService
    {
        private readonly IOperationalDocumentRepository _operationalDocumentRepository;
        private readonly IMapper _mapper;

        public OperationalDocumentService(IOperationalDocumentRepository operationalDocumentRepository,
            IMapper mapper)
        {
            _operationalDocumentRepository = operationalDocumentRepository;
            _mapper = mapper;
        }

        public OperationalDocumentEntity Creat(OperationalDocumentEntity operationalDocument)
        {
            var newOperationalDocument = _operationalDocumentRepository.Creat(_mapper.Map<OperationalDocument>(operationalDocument));
            return _mapper.Map<OperationalDocumentEntity>(newOperationalDocument);
        }

        public void Delete(int id)
        {
            var operationalDocumentToDelete = _operationalDocumentRepository.Get(id)
                ?? throw new NotFoundException($"Element with ID {id} was not found.");
            _operationalDocumentRepository.Delete(operationalDocumentToDelete);
        }

        public OperationalDocumentEntity Get(int id)
        {
            var operationalDocument = _operationalDocumentRepository.Get(id)
                ?? throw new NotFoundException($"Element with ID {id} was not found.");
            return _mapper.Map<OperationalDocumentEntity>(operationalDocument);
        }

        public ICollection<OperationalDocumentEntity> GetAll()
        {
            List<OperationalDocument> operationalDocuments = _operationalDocumentRepository.GetAll().ToList();
            return _mapper.Map<List<OperationalDocumentEntity>>(operationalDocuments);
        }

        public void Update(int id, OperationalDocumentEntity operationalDocument)
        {
            if (id != operationalDocument.Id)
            {
                throw new BadRequestException($"The provided ID {id} doesn't match the model's ID {operationalDocument.Id}.");
            }

            if (!_operationalDocumentRepository.Exist(id))
            {
                throw new NotFoundException($"Element with ID {id} was not found.");
            }

            _operationalDocumentRepository.Update(_mapper.Map<OperationalDocument>(operationalDocument));
        }
    }
}