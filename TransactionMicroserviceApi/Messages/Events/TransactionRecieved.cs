using System;

namespace TransactionMicroserviceApi.Messages.Events
{
    // Immutable
    public class TransactionRecieved : IEvent
    {
        public Guid Id { get; }
        public string ClientId { get; }
        public string WalletAddress { get; }
        public string CurrencyType { get; }

        public TransactionRecieved(string clientId, string walletAddress, string currencyType)
        {
            Id = Guid.NewGuid();
            ClientId = clientId;
            WalletAddress = walletAddress;
            CurrencyType = currencyType;
        }
    }
}
