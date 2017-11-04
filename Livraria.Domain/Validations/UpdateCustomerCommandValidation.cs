using Livraria.Domain.Commands;

namespace Livraria.Domain.Validations
{
    public class UpdateCustomerCommandValidation : CustomerValidation<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}