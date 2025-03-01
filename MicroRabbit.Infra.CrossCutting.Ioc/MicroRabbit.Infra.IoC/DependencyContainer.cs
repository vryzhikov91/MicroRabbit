﻿using MediatR;
using MicroRabbit.Banking.Application.EventHandler;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.CrossCutting.Bus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MicroRabbit.Infra.CrossCutting.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //Domain Bus
            services.AddTransient<IEventBus, RabbitMqBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMqBus(sp.GetService<IMediator>(), scopeFactory,
                    configuration.GetSection("MessageBroker:Host").Value, sp.GetService<ILogger<RabbitMqBus>>());
            });

            //Subscriptions
            services.AddTransient<TransferCreatedEventHandler>();

            //Application Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferLogRepository, TransferLogRepository>();
            services.AddTransient<BankingDbContext>();
        }
    }
}