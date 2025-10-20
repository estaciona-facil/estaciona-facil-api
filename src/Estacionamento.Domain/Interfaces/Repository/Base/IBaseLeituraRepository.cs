using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Interfaces.Repository.Base
{
    public interface IBaseLeituraRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> ObterTodos();
    }
}
