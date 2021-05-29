using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroserviceApi.Dtos;
using TransactionMicroserviceApi.Infrastructure.Interfaces;
using TransactionMicroserviceApi.Messages.Commands;

namespace TransactionMicroserviceApi.Handlers
{
    public class GetTransactionHandler : IQueryHandler<GetTransaction, TransactionDto>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<TransactionDto> HandleAsync(GetTransaction query)
        {
            var transaction = await _transactionRepository.GetById(query.Id);
            if(transaction is null)
            {
                return null;
            }

            return new TransactionDto
            {
                Id = transaction.Id,
                ClientId = transaction.ClientId,
                CurrencyType = transaction.CurrencyType,
                WalletAddress = transaction.WalletAddress,
                RecieverWalletAddress = transaction.RecieverWalletAddress
            };
        }
    }
}
