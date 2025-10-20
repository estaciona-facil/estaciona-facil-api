using Estacionamento.Domain.Entidades;
using Estacionamento.Domain.Interfaces.Context;
using Estacionamento.Infra.Data.Context.Configurations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Estacionamento.Infra.Data.Context
{
    public class EstacionamentoDbContext : DomainDbContext, IEstacionamentoDbContext
    {

        private static readonly string _connectionString = "Data source=db-sqlserver,1433\\sql1;Initial Catalog=EstacionamentoDB;User Id=sa;Password=admin@SqlServerDocker2025";

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Proprietario> Proprietarios { get; set; }

        public EstacionamentoDbContext()
        : base(ObterContextOptions())
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        private static DbContextOptions ObterContextOptions()
        {
            return new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VeiculoConfiguration());
            modelBuilder.ApplyConfiguration(new ProprietarioConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Retorna uma nova conexão independente.
        /// Essa conexão deve receber dispose
        /// </summary>
        /// <returns>Uma instância da implementação de IDbConnection</returns>
        public override IDbConnection RetornaNovaConexao()
        {
            return new SqlConnection(Database.GetDbConnection().ConnectionString);
        }

        public override IDbConnection RetornaNovaConexao(string stringDeConexao)
        {
            return new SqlConnection(stringDeConexao);
        }

        /// <summary>
        /// Essa conexão é a conexão do EF
        /// Essa conexão não deve receber dispose
        /// </summary>
        /// <returns>Uma instância da implementação de IDbConnection</returns>
        public override IDbConnection RetornaConexao()
        {
            return Database.GetDbConnection();
        }
    }
}