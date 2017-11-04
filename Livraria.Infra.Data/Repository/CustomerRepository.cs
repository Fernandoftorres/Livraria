using System.Linq;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using Livraria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LivrariaContext context)
            : base(context)
        {

        }

        public Customer GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
