using System.Linq;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using Livraria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infra.Data.Repository
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public LivroRepository(LivrariaContext context)
            : base(context)
        {

        }
    }
}
