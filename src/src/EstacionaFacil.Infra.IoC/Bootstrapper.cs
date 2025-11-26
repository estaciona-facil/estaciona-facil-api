using EstacionaFacil.Domain.Interfaces.Context;
using EstacionaFacil.Domain.Interfaces.Notificador;
using EstacionaFacil.Domain.Interfaces.Repositories;
using EstacionaFacil.Domain.Interfaces.Services;
using EstacionaFacil.Domain.Notificador;
using EstacionaFacil.Domain.Services;
using EstacionaFacil.Domain.Services.Base;
using EstacionaFacil.Infra.CrossCutting.AppSettings;
using EstacionaFacil.Infra.Data.Context;
using EstacionaFacil.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EstacionaFacil.Infra.IoC
{
    public static class Bootstrapper
    {
        public static IServiceCollection ResolveDependencias(this IServiceCollection services, AppSettings appSettings)
        {
            services.RegistrarInjecaoDependenciasGerais(appSettings);
            services.RegistrarInjecaoDependenciasRepositories();
            services.RegistrarInjecaoDependenciasServicosDomain();
            services.RegistrarInjecaoDependenciasAppServices();
            services.RegistrarInjecaoDependenciasIntegracoes();

            return services;
        }

        public static void RegistrarInjecaoDependenciasGerais(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddScoped(provider =>
            {
                var service = provider.GetService<IEstacionaFacilDbContext>() as EstacionaFacilDbContext;
                return service!;
            });

            services.AddScoped<IEstacionaFacilDbContext, EstacionaFacilDbContext>();
        }

        public static void RegistrarInjecaoDependenciasRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IEstacionamentoRepository, EstacionamentoRepository>();
            services.AddScoped<IRegistroRepository, RegistroRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        }

        public static void RegistrarInjecaoDependenciasServicosDomain(this IServiceCollection services)
        {
            services.AddScoped<NegocioService>();
            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<IProprietarioService, ProprietarioService>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IEstacionamentoService, EstacionamentoService>();
            services.AddScoped<IRegistroService, RegistroService>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IModeloService, ModeloService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
        }

        public static void RegistrarInjecaoDependenciasAppServices(this IServiceCollection services)
        {
            
        }

        public static void RegistrarInjecaoDependenciasIntegracoes(this IServiceCollection services)
        {
            
        }
    }
}
