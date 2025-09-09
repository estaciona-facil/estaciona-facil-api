using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Estacionamento.Domain.DomainObjects;

namespace Estacionamento.Domain.Interfaces.Repository.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnityOfWork UnityOfWork { get; }

        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);

        void Adicionar(T veiculo);
        void Atualizar(T veiculo);
    }
}
