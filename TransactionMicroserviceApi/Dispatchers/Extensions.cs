using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace TransactionMicroserviceApi.Dispatchers
{
    public static class Extensions
    {
        public static void AddDispatchers(this ContainerBuilder builder)
        {
            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>();
            builder.RegisterType<Dispatcher>().As<IDispatcher>();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();
        }

        public static void AddDispatcherService(this IServiceCollection services)
        {
            services.AddTransient<IDispatcher, Dispatcher>();
            services.AddTransient<IQueryDispatcher, QueryDispatcher>();
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
        }

    
    }
}
