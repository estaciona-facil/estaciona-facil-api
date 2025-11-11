using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Estacionamento.Infra.CrossCutting.AppSettings;

namespace Estacionamento.Infra.Data.Context
{
    public class EstacionamentoDbContextFactory : IDesignTimeDbContextFactory<EstacionamentoDbContext>
    {
        public EstacionamentoDbContext CreateDbContext(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            var basePath = Path.Combine(
                Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName,
                "estaciona-facil-api\\src\\Estacionamento.Api"
            );


            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var appSettings = new AppSettings();
            configuration.Bind(appSettings);

            var connectionString = appSettings.ConnectionStrings?.EstacionamentoDb ?? "";
            var options = Options.Create(appSettings);
            return new EstacionamentoDbContext(options);
        }
    }
}
