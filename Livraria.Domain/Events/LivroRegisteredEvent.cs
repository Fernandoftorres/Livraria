using System;
using Livraria.Domain.Core.Events;

namespace Livraria.Domain.Events
{
    public class LivroRegisteredEvent : Event
    {
        public LivroRegisteredEvent(Guid id, string titulo, string autor, int anoPublicacao, int quantidade)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            Quantidade = quantidade;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Titulo { get; private set; }

        public string Autor { get; private set; }

        public int AnoPublicacao { get; private set; }

        public int Quantidade { get; private set; }
    }
}