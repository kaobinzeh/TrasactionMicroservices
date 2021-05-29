using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroserviceApi.Messages
{
    public interface IBusPublisher
    {
        Task PublishAsync<TEvent>(TEvent @event)
          where TEvent : IEvent;
    }
}
