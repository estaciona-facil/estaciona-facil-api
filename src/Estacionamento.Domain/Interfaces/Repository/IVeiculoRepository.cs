using Estacionamento.Domain.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Estacionamento.Domain.Interfaces.Repository.Base;

namespace Estacionamento.Domain.Interfaces.Repository
{
    public interface IVeiculoRepository : IBaseEscritaRepository<Veiculo>, IBaseLeituraRepository<Veiculo>
    {
        Task<IEnumerable<Veiculo>> ObterPorProprietario(Guid proprietarioId);
    }
}
