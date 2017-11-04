using Livraria.Domain.Events;
using MediatR;

namespace Livraria.Domain.EventHandlers
{
    public class LivroEventHandler :
        INotificationHandler<LivroRegisteredEvent>,
        INotificationHandler<LivroUpdatedEvent>,
        INotificationHandler<LivroRemovedEvent>
    {
        public void Handle(LivroUpdatedEvent message)
        {
            // Send some notification e-mail
        }

        public void Handle(LivroRegisteredEvent message)
        {
            // Send some greetings e-mail
        }

        public void Handle(LivroRemovedEvent message)
        {
            // Send some see you soon e-mail
        }
    }
}