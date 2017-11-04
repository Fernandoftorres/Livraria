using System;
using Livraria.Domain.Commands;
using Livraria.Domain.Core.Bus;
using Livraria.Domain.Core.Notifications;
using Livraria.Domain.Events;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using MediatR;

namespace Livraria.Domain.CommandHandlers
{
    public class LivroCommandHandler : CommandHandler,
        INotificationHandler<RegisterNewLivroCommand>,
        INotificationHandler<UpdateLivroCommand>,
        INotificationHandler<RemoveLivroCommand>
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMediatorHandler Bus;

        public LivroCommandHandler(ILivroRepository livroRepository, 
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _livroRepository = livroRepository;
            Bus = bus;
        }

        public void Handle(RegisterNewLivroCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var livro = new Livro(Guid.NewGuid(), 
                                  message.Titulo, 
                                  message.Autor, 
                                  message.AnoPublicacao,
                                  message.Quantidade);
            
            _livroRepository.Add(livro);

            if (Commit())
            {
                Bus.RaiseEvent(new LivroRegisteredEvent(livro.Id, 
                                                        livro.Titulo, 
                                                        livro.Autor, 
                                                        livro.AnoPublicacao,
                                                        livro.Quantidade));
            }
        }

        public void Handle(UpdateLivroCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var livro = new Livro(message.Id, 
                                  message.Titulo, 
                                  message.Autor, 
                                  message.AnoPublicacao,
                                  message.Quantidade);

            _livroRepository.Update(livro);

            if (Commit())
            {
                Bus.RaiseEvent(new LivroUpdatedEvent(livro.Id, 
                                                     livro.Titulo, 
                                                     livro.Autor, 
                                                     livro.AnoPublicacao,
                                                     livro.Quantidade));
            }
        }

        public void Handle(RemoveLivroCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            _livroRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new LivroRemovedEvent(message.Id));
            }
        }

        public void Dispose()
        {
            _livroRepository.Dispose();
        }
    }
}