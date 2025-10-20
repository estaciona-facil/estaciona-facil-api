using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Interfaces.Context
{
    public interface IDomainDbContext
    {
       Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        
        Task BeginTranAsync(CancellationToken cancellationToken = default);
        
        void CommitTran();
        
        void RollbackTran();
        
        IDbConnection RetornaNovaConexao();
        
        IDbConnection RetornaNovaConexao(string stringDeConexao);
        
        IDbConnection RetornaConexao();
    }
}
