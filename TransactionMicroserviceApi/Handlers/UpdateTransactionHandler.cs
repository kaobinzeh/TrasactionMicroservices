using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroserviceApi.Entities;
using TransactionMicroserviceApi.Infrastructure.Interfaces;
using TransactionMicroserviceApi.Messages;
using TransactionMicroserviceApi.Messages.Commands;
using TransactionMicroserviceApi.Messages.Events;

namespace TransactionMicroserviceApi.Handlers
{
    public class UpdateTransactionHandler : ICommandHandler<UpdateTransaction>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ILogger<UpdateTransactionHandler> _logger;
        private readonly IBusPublisher _busPublisher;

        public UpdateTransactionHandler(ITransactionRepository transactionRepository, ILogger<UpdateTransactionHandler> logger, IBusPublisher busPublisher)
        {
            _transactionRepository = transactionRepository;
            _logger = logger;
            _busPublisher = busPublisher;
        }
        public async Task HandleAsync(UpdateTransaction command)
        {
            var result = _transactionRepository.DoesTransactionExists(command.ClientId, command.WalletAddress, command.RecieverWalletAddress);
            if (result)
            {
                _logger.LogError($"Duplicate transaction, Transaction with Client Id {command.ClientId} and wallent address {command.WalletAddress} already exist");

                return;
            }

            var transaction = new Transactions(command);
            await _transactionRepository.AddTransaction(transaction);
            _logger.LogInformation($"Transaction Added successfully");

            //Publish event
            await _busPublisher.PublishAsync(new TransactionRecieved(command.ClientId, command.WalletAddress, command.CurrencyType));
        }
    }
}
