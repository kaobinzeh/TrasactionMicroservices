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

        public Transactions()
        {
        }

        public Transactions(UpdateTransaction command)
        {
            if (command.Id == Guid.Empty)
            {
                throw new Exception("Invalid Transaction Id");
            }

            if (string.IsNullOrEmpty(command.ClientId))
            {
                throw new Exception("Invalid Client Id");
            }

            if (string.IsNullOrEmpty(command.WalletAddress))
            {
                throw new Exception("Invalid Wallet Address");
            }
            
            if (string.IsNullOrEmpty(command.RecieverWalletAddress))
            {
                throw new Exception("Invalid Reciever Wallet Address Address");
            }

            if (string.IsNullOrEmpty(command.CurrencyType))
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
