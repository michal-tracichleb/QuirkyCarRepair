using AutoMapper;
using QuirkyCarRepair.BLL.Areas.Warehouse.Entities;
using QuirkyCarRepair.BLL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Interfaces;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;
using QuirkyCarRepair.DAL.Exceptions;

namespace QuirkyCarRepair.BLL.Areas.Warehouse.Services
{
    internal class PartTransactionService : IPartTransactionService
    {
        private readonly IPartTransactionRepository _partTransactionRepository;
        private readonly IMapper _mapper;

        public PartTransactionService(IPartTransactionRepository partTransactionRepository,
            IMapper mapper)
        {
            _partTransactionRepository = partTransactionRepository;
            _mapper = mapper;
        }

        public PartTransactionEntity Creat(PartTransactionEntity partTransaction)
        {
            var newPartTransaction = _partTransactionRepository.Creat(_mapper.Map<PartTransaction>(partTransaction));
            return _mapper.Map<PartTransactionEntity>(newPartTransaction);
        }

        public void Delete(int id)
        {
            var partTransactionToDelete = _partTransactionRepository.Get(id)
                ?? throw new NotFoundException($"Element with ID {id} was not found.");
            _partTransactionRepository.Delete(partTransactionToDelete);
        }

        public PartTransactionEntity Get(int id)
        {
            var partTransaction = _partTransactionRepository.Get(id)
                ?? throw new NotFoundException($"Element with ID {id} was not found.");
            return _mapper.Map<PartTransactionEntity>(partTransaction);
        }

        public ICollection<PartTransactionEntity> GetAll()
        {
            List<PartTransaction> partTransactions = _partTransactionRepository.GetAll().ToList();
            return _mapper.Map<List<PartTransactionEntity>>(partTransactions);
        }

        public void Update(int id, PartTransactionEntity partTransaction)
        {
            if (id != partTransaction.Id)
            {
                throw new BadRequestException($"The provided ID {id} doesn't match the model's ID {partTransaction.Id}.");
            }

            if (!_partTransactionRepository.Exist(id))
            {
                throw new NotFoundException($"Element with ID {id} was not found.");
            }

            _partTransactionRepository.Update(_mapper.Map<PartTransaction>(partTransaction));
        }
    }
}