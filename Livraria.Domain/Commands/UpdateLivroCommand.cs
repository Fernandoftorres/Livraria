using System;
using Livraria.Domain.Validations;

namespace Livraria.Domain.Commands
{
    public class UpdateLivroCommand : LivroCommand
    {
        public UpdateLivroCommand(Guid id, string titulo, string autor, int anoPublicacao, int quantidade)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            Quantidade = quantidade;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateLivroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}