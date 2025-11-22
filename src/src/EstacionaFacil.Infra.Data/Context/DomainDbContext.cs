using Microsoft.EntityFrameworkCore;
using EstacionaFacil.Domain.Entities.Base;
using EstacionaFacil.Domain.Interfaces.Context;
using System.Data;

namespace EstacionaFacil.Infra.Data.Context
{
    public abstract class DomainDbContext : DbContext, IDomainDbContext
    {
        protected DomainDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public abstract IDbConnection RetornaNovaConexao();
        public abstract IDbConnection RetornaNovaConexao(string connectionString);
        public abstract IDbConnection RetornaConexao();

        public async Task BeginTranAsync()
        {
            await Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await Database.CommitTransactionAsync();
        }

        public async Task Rollback()
        {
            await Database.RollbackTransactionAsync();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }       
    }
}
