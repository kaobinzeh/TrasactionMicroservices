using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroserviceApi.DBContext;
using TransactionMicroserviceApi.Dtos;
using TransactionMicroserviceApi.Handlers;
using TransactionMicroserviceApi.Infrastructure.Interfaces;
using TransactionMicroserviceApi.Infrastructure.Services;
using TransactionMicroserviceApi.Messages.Commands;

namespace TransactionMicroserviceApi.DependencyInjection
{
    public static class Extensions
    {
        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<UpdateTransaction>, UpdateTransactionHandler>();
            services.AddTransient<IQueryHandler<GetTransaction, TransactionDto>, GetTransactionHandler>();
            services.AddTransient<ITransactionRepository, TransactionServices>();
        }
    }
}
