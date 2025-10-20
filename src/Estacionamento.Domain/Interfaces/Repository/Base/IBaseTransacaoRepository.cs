using System;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Interfaces.Repository.Base
{
    public interface IBaseTransacaoRepository<T> : IDisposable where T : class
    {
        Task<int> SaveChanges();
        Task BeginTran();
        Task CommitTran();
        Task RollbackTran();
    }
}
