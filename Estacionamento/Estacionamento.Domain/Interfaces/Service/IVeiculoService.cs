using Estacionamento.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Interfaces.Service
{
    public interface IVeiculoService : IService<Veiculo>
    {
        Task<IEnumerable<Veiculo>> ObterPorProprietario(Guid proprietarioId);
    }
}
