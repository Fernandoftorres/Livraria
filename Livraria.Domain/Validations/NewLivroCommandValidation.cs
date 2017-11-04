using Livraria.Domain.Commands;

namespace Livraria.Domain.Validations
{
    public class NewLivroCommandValidation : LivroValidation<RegisterNewLivroCommand>
    {
        public NewLivroCommandValidation()
        {
            ValidateTitulo();
            ValidateAutor();
            ValidateAnoPublicacao();
            ValidateQuantidade();
        }
    }
}