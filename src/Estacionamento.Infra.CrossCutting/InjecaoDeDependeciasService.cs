using Estacionamento.Domain.Interfaces.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Estacionamento.Infra.CrossCutting
{
    public class InjecaoDeDependeciasService : IInjecaoDeDependeciasService
    {
        private readonly IServiceProvider _serviceProvider;

        public InjecaoDeDependeciasService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void InstanciaDependencia<T>(out T interfaceParaInstancia) => interfaceParaInstancia = _serviceProvider.GetService<T>();
    }
}
