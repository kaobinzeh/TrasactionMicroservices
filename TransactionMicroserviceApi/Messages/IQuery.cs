using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroserviceApi.Messages
{
    public interface IQuery
    {
    }

    public interface IQuery<T> : IQuery
    {

    }
}
