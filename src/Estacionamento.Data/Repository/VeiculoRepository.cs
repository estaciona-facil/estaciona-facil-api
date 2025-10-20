using Estacionamento.Domain.Entidades;
using Estacionamento.Domain.Interfaces.Repository;
using Estacionamento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Infra.Data.Repository
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(EstacionamentoDbContext context) : base(context) { }

        public async Task<IEnumerable<Veiculo>> ObterPorProprietario(Guid proprietarioId)
        {
            return await Entidades.Where(x => x.ProprietarioId == proprietarioId)
                .ToListAsync();
        }
    }
}
