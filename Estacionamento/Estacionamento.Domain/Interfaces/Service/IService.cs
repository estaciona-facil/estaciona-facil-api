using Estacionamento.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Interfaces.Service
{
    public interface IService<T> where T : IAggregateRoot
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);

        void Adicionar(T veiculo);
        void Atualizar(T veiculo);
    }
}
