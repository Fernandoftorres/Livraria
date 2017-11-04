using System;
using Livraria.Domain.Validations;

namespace Livraria.Domain.Commands
{
    public class RemoveLivroCommand : LivroCommand
    {
        public RemoveLivroCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveLivroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}