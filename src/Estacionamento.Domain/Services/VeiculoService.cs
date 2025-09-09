using Estacionamento.Domain.Entidades;
using Estacionamento.Domain.Interfaces.Repository;
using Estacionamento.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Services
{
    public class VeiculoService : BaseService<Veiculo>, IVeiculoService
    {
        private readonly IVeiculoRepository _repository;

        public VeiculoService(IVeiculoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Veiculo>> ObterPorProprietario(Guid proprietarioId)
        {
            return await _repository.ObterPorProprietario(proprietarioId);
        }
    }
}
