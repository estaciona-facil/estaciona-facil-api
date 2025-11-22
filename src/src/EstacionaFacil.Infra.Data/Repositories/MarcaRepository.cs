using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Repositories;
using EstacionaFacil.Infra.Data.Context;
using EstacionaFacil.Infra.Data.Repositories.Base;

namespace EstacionaFacil.Infra.Data.Repositories
{
    public class MarcaRepository : EntidadeDescricaoRepository<Marca>, IMarcaRepository
    {
        public MarcaRepository(EstacionaFacilDbContext contexto) : base(contexto) { }
    }
}
