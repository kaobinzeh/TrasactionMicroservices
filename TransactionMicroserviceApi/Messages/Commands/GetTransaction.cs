using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroserviceApi.Dtos;

namespace TransactionMicroserviceApi.Messages.Commands
{
    public class GetTransaction : IQuery<TransactionDto>
    {
        public Guid Id { get; set; }
    }
}
