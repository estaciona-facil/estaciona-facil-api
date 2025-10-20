using Estacionamento.Domain.Interfaces.Context;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Interfaces.UoW
{
    public interface IUnitOfWork<T> where T : IDomainDbContext
    {
        Task<int> Commit();
        Task BeginTran();
        Task CommitTran();
        Task RollbackTran();
    }
}
