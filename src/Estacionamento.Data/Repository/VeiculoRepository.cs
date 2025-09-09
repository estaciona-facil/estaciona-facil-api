using Estacionamento.Data.Context;
using Estacionamento.Domain.Entidades;
using Estacionamento.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Data.Repository
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(ApplicationContext context) : base(context) { }

        public async Task<IEnumerable<Veiculo>> ObterPorProprietario(Guid proprietarioId)
        {
            return await _context.AsNoTracking()
                .Include(x => x.Proprietario)
                .Where(x => x.ProprietarioId == proprietarioId)
                .ToListAsync();
        }
    }
}
