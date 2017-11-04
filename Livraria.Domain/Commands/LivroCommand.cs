using System;
using Livraria.Domain.Core.Commands;

namespace Livraria.Domain.Commands
{
    public abstract class LivroCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Titulo { get; protected set; }

        public string Autor { get; protected set; }

        public int AnoPublicacao { get; protected set; }

        public int Quantidade { get; protected set; }
    }
}