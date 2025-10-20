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
    public class ProprietarioRepository : BaseRepository<Proprietario>, IProprietarioRepository
    {
        public ProprietarioRepository(EstacionamentoDbContext context) : base(context) { }
    }
}
