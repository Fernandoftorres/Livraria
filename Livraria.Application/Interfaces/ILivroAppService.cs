using System;
using System.Collections.Generic;
using Livraria.Application.ViewModels;

namespace Livraria.Application.Interfaces
{
    public interface ILivroAppService : IDisposable
    {
        void Register(LivroViewModel livroViewModel);
        IEnumerable<LivroViewModel> GetAll();
        LivroViewModel GetById(Guid id);
        void Update(LivroViewModel livroViewModel);
        void Remove(Guid id);
    }
}
