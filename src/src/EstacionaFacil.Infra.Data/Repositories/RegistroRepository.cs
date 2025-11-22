using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Repositories;
using EstacionaFacil.Infra.Data.Context;
using EstacionaFacil.Infra.Data.Repositories.Base;

namespace EstacionaFacil.Infra.Data.Repositories
{
    public class RegistroRepository : EntidadeRelacionamentoRepository<Registro>, IRegistroRepository
    {
        public RegistroRepository(EstacionaFacilDbContext contexto) : base(contexto) { }
    }
}
