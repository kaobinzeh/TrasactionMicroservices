using Autofac;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TransactionMicroserviceApi.DBContext;
using TransactionMicroserviceApi.Dispatchers;

namespace TransactionMicroserviceApi.DependencyInjection
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsImplementedInterfaces();
            //var assembly = typeof(Startup).Assembly;

            //builder.RegisterAssemblyTypes(assembly)
            //   .Where(t => t.Name.Contains("Repository"))
            //   .AsImplementedInterfaces()
            //   .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(assembly)
            //   .Where(t => t.Name.Contains("Handler"))
            //   .AsImplementedInterfaces();


            builder.AddDispatchers();
        }
    }
}
