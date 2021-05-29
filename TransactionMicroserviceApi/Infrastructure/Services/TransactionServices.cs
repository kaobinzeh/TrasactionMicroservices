using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroserviceApi.DBContext;
using TransactionMicroserviceApi.Dtos;
using TransactionMicroserviceApi.Entities;
using TransactionMicroserviceApi.Infrastructure.Interfaces;

namespace TransactionMicroserviceApi.Infrastructure.Services
{
    public class TransactionServices : ITransactionRepository
    {
        private readonly ApplicationDBContext _context;

        public TransactionServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddTransaction(Transactions createTransaction)
        {
            try
            {
                var res = await _context.Transactions.AddAsync(createTransaction);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DoesTransactionExists(string clientId, string walletAddress, string recieverWalletAddress)        
           => _context.Transactions.Any(t => t.ClientId == clientId && t.WalletAddress == walletAddress && t.RecieverWalletAddress == recieverWalletAddress);


        public async Task<Transactions> GetById(Guid Id)
        => await _context.Transactions.FindAsync(Id);

        public async Task<IEnumerable<Transactions>> GetClientTransactions(string clientId)
        => _context.Transactions.Where(t => t.ClientId == clientId).AsEnumerable();


        public async  Task<IEnumerable<Transactions>> GetTransactions()
            =>  _context.Transactions.AsEnumerable<Transactions>();
    }
}
