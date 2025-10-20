using Estacionamento.Application.AppServices;
using Estacionamento.Application.AutoMapper;
using Estacionamento.Application.Interfaces.AppServices;
using Estacionamento.Domain.Interfaces.Context;
using Estacionamento.Domain.Interfaces.Repository;
using Estacionamento.Domain.Interfaces.Service;
using Estacionamento.Domain.Interfaces.UoW;
using Estacionamento.Domain.Interfaces.Utils;
using Estacionamento.Domain.Services;
using Estacionamento.Infra.CrossCutting;
using Estacionamento.Infra.Data.Context;
using Estacionamento.Infra.Data.Repository;
using Estacionamento.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace Estacionamento.Infra.IoC
{
    public static class Bootstrapper
    {
        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {
            services.RegistrarInjecaoDependenciasGerais();
            services.RegistrarInjecaoDependenciasRepositories();
            services.RegistrarInjecaoDependenciasServicosDomain();
            services.RegistrarInjecaoDependenciasServicosDeAplicacao();

            return services;
        }

        private static void RegistrarInjecaoDependenciasGerais(this IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(config =>
            {
                config.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
                config.AddProfile<DomainParaViewModelProfile>();
                config.AddProfile<ViewModelParaDomainProfile>();
            });

            // Contexto Multiseguros
            services.AddScoped(provider =>
            {
                // pega a mesma instância configurada para a injeção da interface do contexto,
                // assim é possível injetar direto via classe para usar na camada de dados e via interface nas demais camadas
                var service = provider.GetService<IEstacionamentoDbContext>() as EstacionamentoDbContext;
                return service!;
            });
            services.AddScoped<IEstacionamentoDbContext, EstacionamentoDbContext>();

            services.AddScoped<IInjecaoDeDependeciasService, InjecaoDeDependeciasService>();

            // Adicionando injeção de dependência para UoW
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        }

        private static void RegistrarInjecaoDependenciasServicosDomain(this IServiceCollection services)
        {
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IProprietarioService, ProprietarioService>();
        }

        private static void RegistrarInjecaoDependenciasRepositories(this IServiceCollection services)
        {
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
        }

        private static void RegistrarInjecaoDependenciasServicosDeAplicacao(this IServiceCollection services)
        {
            services.AddScoped<IVeiculoAppService, VeiculoAppService>();
            services.AddScoped<IProprietarioAppService, ProprietarioAppService>();
        }
    }
}
