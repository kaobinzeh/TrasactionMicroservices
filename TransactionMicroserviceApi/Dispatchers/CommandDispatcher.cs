using Autofac;
using System.Threading.Tasks;
using TransactionMicroserviceApi.Handlers;
using TransactionMicroserviceApi.Messages;

namespace TransactionMicroserviceApi.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task SendAsync<T>(T command) where T : ICommand
         => await _context.Resolve<ICommandHandler<T>>().HandleAsync(command);
    }
}
