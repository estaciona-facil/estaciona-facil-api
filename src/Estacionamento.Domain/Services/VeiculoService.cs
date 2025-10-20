using Estacionamento.Domain.Entidades;
using Estacionamento.Domain.Interfaces.Repository;
using Estacionamento.Domain.Interfaces.Service;
using Estacionamento.Domain.Interfaces.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Services
{
    public class VeiculoService : Service<Veiculo>, IVeiculoService
    {
        private readonly IVeiculoRepository _repository;

        public VeiculoService(IInjecaoDeDependeciasService injecaoDeDependeciasService) : base(injecaoDeDependeciasService)
        {
            injecaoDeDependeciasService.InstanciaDependencia(out _repository);
            DefinirInstanciasDeRepositorios();
        }

        public sealed override void DefinirInstanciasDeRepositorios()
        {
            DefinirRepositoryEscrita(_repository);
            DefinirRepositoryLeitura(_repository);
        }

        public async Task<IEnumerable<Veiculo>> ObterPorProprietario(Guid proprietarioId)
        {
            return await _repository.ObterPorProprietario(proprietarioId);
        }
    }
}
