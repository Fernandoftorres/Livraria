using AutoMapper;
using Livraria.Application.Interfaces;
using Livraria.Application.Services;
using Livraria.Domain.CommandHandlers;
using Livraria.Domain.Commands;
using Livraria.Domain.Core.Bus;
using Livraria.Domain.Core.Notifications;
using Livraria.Domain.EventHandlers;
using Livraria.Domain.Events;
using Livraria.Domain.Interfaces;
using Livraria.Infra.CrossCutting.Bus;
using Livraria.Infra.Data.Context;
using Livraria.Infra.Data.Repository;
using Livraria.Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Livraria.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<INotificationHandler<RegisterNewCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveCustomerCommand>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<LivrariaContext>();

        }
    }
}