using Estacionamento.Data.Context;
using Estacionamento.Data.Repository;
using Estacionamento.Domain.Interfaces.Repository;
using Estacionamento.Domain.Interfaces.Repository.Data;
using Estacionamento.Domain.Interfaces.Service;
using Estacionamento.Domain.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Estacionamento.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

       public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
