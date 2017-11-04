using System;
using System.Collections.Generic;
using Livraria.Application.EventSourcedNormalizers;
using Livraria.Application.ViewModels;

namespace Livraria.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        void Register(CustomerViewModel customerViewModel);
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel GetById(Guid id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(Guid id);
    }
}
