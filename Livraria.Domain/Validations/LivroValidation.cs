using System;
using Livraria.Domain.Commands;
using FluentValidation;

namespace Livraria.Domain.Validations
{
    public abstract class LivroValidation<T> : AbstractValidator<T> where T : LivroCommand
    {
        protected void ValidateTitulo()
        {
            RuleFor(c => c.Titulo)
                .NotEmpty().WithMessage("O campo titulo é obrigatório")
                .Length(2, 100).WithMessage("O titulo deve ter entre 2 e 100 caracteres");
        }

        protected void ValidateAutor()
        {
            RuleFor(c => c.Autor)
                .NotEmpty().WithMessage("O campo autor é obrigatório")
                .Length(2, 30).WithMessage("O nome do autor deve ter entre 2 e 30 caracteres");

        }

        protected void ValidateAnoPublicacao()
        {
            RuleFor(c => c.AnoPublicacao)
                .NotEmpty()
                .ExclusiveBetween(1900, 2018)
                .WithMessage("Ano informado inválido");
        }

        protected void ValidateQuantidade()
        {
            RuleFor(c => c.Quantidade)
                .NotEmpty()
                .ExclusiveBetween(0, int.MaxValue)
                .WithMessage("Quantidade informada inválida");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

    }
}