using Livraria.Domain.Commands;

namespace Livraria.Domain.Validations
{
    public class UpdateLivroCommandValidation : LivroValidation<UpdateLivroCommand>
    {
        public UpdateLivroCommandValidation()
        {
            ValidateId();
            ValidateTitulo();
            ValidateAutor();
            ValidateAnoPublicacao();
            ValidateQuantidade();
        }
    }
}