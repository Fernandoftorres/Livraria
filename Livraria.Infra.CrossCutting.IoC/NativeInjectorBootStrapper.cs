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
            services.AddScoped<ILivroAppService, LivroAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<LivroRegisteredEvent>, LivroEventHandler>();
            services.AddScoped<INotificationHandler<LivroUpdatedEvent>, LivroEventHandler>();
            services.AddScoped<INotificationHandler<LivroRemovedEvent>, LivroEventHandler>();

            // Domain - Commands
            services.AddScoped<INotificationHandler<RegisterNewLivroCommand>, LivroCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateLivroCommand>, LivroCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveLivroCommand>, LivroCommandHandler>();

            // Infra - Data
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<LivrariaContext>();

        }
    }
}