using Estacionamento.Domain.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Estacionamento.Infra.Data.Context
{
    public abstract class DomainDbContext : DbContext, IDomainDbContext
    {
        protected DomainDbContext(DbContextOptions options)
            : base(options)
        {

        }

        /// <summary>
        /// Retorna uma nova conexão independente.
        /// Essa conexão deve receber dispose
        /// </summary>
        /// <returns>Uma instância da implementação de IDbConnection</returns>
        public abstract IDbConnection RetornaNovaConexao();

        /// <summary>
        /// Retorna uma nova conexão independente.
        /// Essa conexão deve receber dispose
        /// </summary>
        /// <param name="stringDeConexao">string de conexão do banco de dados</param>
        /// <returns>Uma instância da implementação de IDbConnection</returns>
        public abstract IDbConnection RetornaNovaConexao(string stringDeConexao);

        /// <summary>
        /// Essa conexão é a conexão do EF
        /// Essa conexão não deve receber dispose
        /// </summary>
        /// <returns>Uma instância da implementação de IDbConnection</returns>
        public abstract IDbConnection RetornaConexao();

        public async Task BeginTranAsync(CancellationToken cancellationToken = default)
        {
            await Database.BeginTransactionAsync(cancellationToken);
        }

        public void CommitTran()
        {
            Database.CommitTransaction();
        }

        public void RollbackTran()
        {
            Database.RollbackTransaction();
        }
    }
}
