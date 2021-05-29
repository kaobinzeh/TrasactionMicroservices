using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroserviceApi.Dtos;
using TransactionMicroserviceApi.Entities;

namespace TransactionMicroserviceApi.Infrastructure.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transactions>> GetTransactions();
		Task<bool> AddTransaction(Transactions createTransaction);
        Task<Transactions> GetById(Guid Id);
        Task<IEnumerable<Transactions>> GetClientTransactions(string clientId);
        bool DoesTransactionExists(string clientId, string walletAddress, string recieverWalletAddress);

	}
}
