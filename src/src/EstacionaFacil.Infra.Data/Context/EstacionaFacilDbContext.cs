using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Context;
using EstacionaFacil.Infra.CrossCutting.AppSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace EstacionaFacil.Infra.Data.Context
{
    public class EstacionaFacilDbContext : DomainDbContext, IEstacionaFacilDbContext
    {
        public DbSet<Proprietario> Proprietarios { get; set; }   
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Estacionamento> Estacionamentos { get; set; }
        public DbSet<Registro> Registros { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }


        public EstacionaFacilDbContext(IOptions<AppSettings> appSettings)
        : base(ObterContextOptions(appSettings.Value))
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        private static DbContextOptions ObterContextOptions(AppSettings appSettings)
        {
            return new DbContextOptionsBuilder().UseNpgsql(appSettings?.ConnectionStrings?.EstacionaFacilDB ?? string.Empty).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EstacionaFacilDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override IDbConnection RetornaNovaConexao()
        {
            return new NpgsqlConnection(Database.GetDbConnection().ConnectionString);
        }

        public override IDbConnection RetornaNovaConexao(string connectionString)
        {

            return new NpgsqlConnection(Database.GetDbConnection().ConnectionString);
        }

        public override IDbConnection RetornaConexao()
        {
            return Database.GetDbConnection();
        }
    }
}
