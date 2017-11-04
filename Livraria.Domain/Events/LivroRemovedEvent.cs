using System;
using Livraria.Domain.Core.Events;

namespace Livraria.Domain.Events
{
    public class LivroRemovedEvent : Event
    {
        public LivroRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}