using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Repositories;
using EstacionaFacil.Infra.Data.Context;
using EstacionaFacil.Infra.Data.Repositories.Base;

namespace EstacionaFacil.Infra.Data.Repositories
{
    public class ProprietarioRepository : EntidadeDominioRepository<Proprietario>, IProprietarioRepository
    {
        public ProprietarioRepository(EstacionaFacilDbContext contexto) : base(contexto) { }
    }
}
