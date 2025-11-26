using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Services;
using EstacionaFacil.Infra.CrossCutting.AppSettings;
using EstacionaFacil.Infra.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace EstacionaFacil.Tests
{
    public class BaseStartup : IDisposable
    {
        public BaseStartup()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public IConfigurationRoot Configuration { get; private set; }
        public ServiceProvider ServiceProvider { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            Configuration = builder.Build();
            services.AddSingleton(Configuration);

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = Configuration.Get<AppSettings>() ?? new AppSettings();

            services.ResolveDependencias(appSettings);

            _ = OnConfigureServices(services);
        }

        public void Dispose()
        {
            ServiceProvider.Dispose();
        }

        [ExcludeFromCodeCoverage]
        public virtual IServiceCollection OnConfigureServices(IServiceCollection services)
        {
            return services;
        }
    }
}
