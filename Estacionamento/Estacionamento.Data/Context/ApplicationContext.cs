using Estacionamento.Data.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Data.Context
{
    public class ApplicationContext : DbContext
    {
        private readonly string _connectionString = "Data source=(localdb)\\mssqllocaldb;Initial Catalog=Estacionamento;Integrated Security=true";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}