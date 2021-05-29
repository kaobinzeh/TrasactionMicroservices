using System;
using TransactionMicroserviceApi.Messages.Commands;

namespace TransactionMicroserviceApi.Entities
{
    public class Transactions
    {
        public Guid Id { get; private set; }
        public string ClientId { get; private set; }
        public string WalletAddress { get; private set; }
        public string RecieverWalletAddress { get; private set; }
        public string CurrencyType { get; private set; }
        public DateTime CreateAt { get; private set; }

        public Transactions(UpdateTransaction command)
        {
            if (Id == Guid.Empty)
            {
                throw new Exception("Invalid Transaction Id");
            }

            if (string.IsNullOrEmpty(ClientId))
            {
                throw new Exception("Invalid Client Id");
            }

            if (string.IsNullOrEmpty(WalletAddress))
            {
                throw new Exception("Invalid Wallet Address");
            }
            
            if (string.IsNullOrEmpty(RecieverWalletAddress))
            {
                throw new Exception("Invalid Reciever Wallet Address Address");
            }

            if (string.IsNullOrEmpty(CurrencyType))
            {
                throw new Exception("Invalid Currency Type ");
            }

            Id = command.Id;
            ClientId = command.ClientId;
            WalletAddress = command.WalletAddress;
            RecieverWalletAddress = command.RecieverWalletAddress;
            CurrencyType = command.CurrencyType;

        }

        public void Created()
        {
            CreateAt = DateTime.UtcNow;
        }

    }


}
