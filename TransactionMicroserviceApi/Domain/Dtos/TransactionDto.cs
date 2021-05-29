using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroserviceApi.Dtos
{
    public class TransactionDto
    {
        public Guid Id { get; set; }

        public string ClientId { get; set; }
        public string WalletAddress { get; set; }
        public string RecieverWalletAddress { get; set; }
        public string CurrencyType { get; set; }
    }
}
