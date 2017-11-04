using Livraria.Domain.Models;

namespace Livraria.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}