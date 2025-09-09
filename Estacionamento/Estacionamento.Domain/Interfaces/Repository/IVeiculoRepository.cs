using Estacionamento.Domain.Interfaces.Repository.Data;
using Estacionamento.Domain.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Estacionamento.Domain.Interfaces.Repository
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        Task<IEnumerable<Veiculo>> ObterPorProprietario(Guid proprietarioId);
    }
}
