using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroserviceApi.Messages.Commands
{
    public class BusPublisher : IBusPublisher
    {
        public Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            //Do nothing
            return Task.CompletedTask;
        }
    }
}
