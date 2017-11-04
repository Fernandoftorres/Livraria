using System;
using Livraria.Domain.Core.Commands;

namespace Livraria.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
