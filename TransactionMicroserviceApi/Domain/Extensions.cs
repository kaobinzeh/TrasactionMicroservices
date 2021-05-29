using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroserviceApi.Domain
{
    public static class Extensions
    {
        public static void AddSql(this ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                var options = configuration.GetOptions<DbOptions>("ConnectionStrings");

                return options;
            }).SingleInstance();
        }
    }
}
