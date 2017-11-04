using Livraria.Domain.Commands;

namespace Livraria.Domain.Validations
{
    public class RemoveLivroCommandValidation : LivroValidation<RemoveLivroCommand>
    {
        public RemoveLivroCommandValidation()
        {
            ValidateId();
        }
    }
}