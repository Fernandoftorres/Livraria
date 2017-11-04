using System;
using Livraria.Domain.Validations;

namespace Livraria.Domain.Commands
{
    public class RegisterNewLivroCommand : LivroCommand
    {
        public RegisterNewLivroCommand(string titulo, string autor, int anoPublicacao, int quantidade)
        {
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            Quantidade = quantidade;
        }

        public override bool IsValid()
        {
            ValidationResult = new NewLivroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}