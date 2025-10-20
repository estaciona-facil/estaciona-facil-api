using Estacionamento.Domain.Entidades;
using Estacionamento.Domain.Interfaces.Repository;
using Estacionamento.Domain.Interfaces.Service;
using Estacionamento.Domain.Interfaces.Utils;
namespace Estacionamento.Domain.Services
{
    public class ProprietarioService : Service<Proprietario>, IProprietarioService
    {
        private readonly IProprietarioRepository _repository;

        public ProprietarioService(IInjecaoDeDependeciasService injecaoDeDependeciasService) : base(injecaoDeDependeciasService)
        {
            injecaoDeDependeciasService.InstanciaDependencia(out _repository);
            DefinirInstanciasDeRepositorios();
        }

        public sealed override void DefinirInstanciasDeRepositorios()
        {
            DefinirRepositoryEscrita(_repository);
            DefinirRepositoryLeitura(_repository);
        }
    }
}
