using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroserviceApi.Messages.Commands
{
    public class UpdateTransaction : ICommand
    {
        public Guid Id { get; }
        public string ClientId { get; }
        public string WalletAddress { get; }
        public string RecieverWalletAddress { get; }
        public string CurrencyType { get; }

        public UpdateTransaction(string clientId, string walletAddress, string recieverWalletAddress, string currencyType)
        {
            Id = Guid.NewGuid();
            ClientId = clientId;
            WalletAddress = walletAddress;
            RecieverWalletAddress = recieverWalletAddress;
            CurrencyType = currencyType;
        }
    }
}
