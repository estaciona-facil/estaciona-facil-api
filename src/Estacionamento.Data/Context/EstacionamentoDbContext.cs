using Estacionamento.Domain.Entidades;
using Estacionamento.Domain.Interfaces.Context;
using Estacionamento.Infra.CrossCutting.AppSettings;
using Estacionamento.Infra.Data.Context.Configurations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;

namespace Estacionamento.Infra.Data.Context
{
    public class EstacionamentoDbContext : DomainDbContext, IEstacionamentoDbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Proprietario> Proprietarios { get; set; }

        public EstacionamentoDbContext(IOptions<AppSettings> appSettings)
        : base(ObterContextOptions(appSettings.Value))
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        private static DbContextOptions ObterContextOptions(AppSettings appSettings)
        {
            return new DbContextOptionsBuilder().UseSqlServer(appSettings?.ConnectionStrings?.EstacionamentoDb ?? string.Empty).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VeiculoConfiguration());
            modelBuilder.ApplyConfiguration(new ProprietarioConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Retorna uma nova conex�o independente.
        /// Essa conex�o deve receber dispose
        /// </summary>
        /// <returns>Uma inst�ncia da implementa��o de IDbConnection</returns>
        public override IDbConnection RetornaNovaConexao()
        {
            return new SqlConnection(Database.GetDbConnection().ConnectionString);
        }

        public override IDbConnection RetornaNovaConexao(string stringDeConexao)
        {
            return new SqlConnection(stringDeConexao);
        }

        /// <summary>
        /// Essa conex�o � a conex�o do EF
        /// Essa conex�o n�o deve receber dispose
        /// </summary>
        /// <returns>Uma inst�ncia da implementa��o de IDbConnection</returns>
        public override IDbConnection RetornaConexao()
        {
            return Database.GetDbConnection();
        }
    }
}