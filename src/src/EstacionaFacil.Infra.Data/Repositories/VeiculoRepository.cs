using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Repositories;
using EstacionaFacil.Infra.Data.Context;
using EstacionaFacil.Infra.Data.Repositories.Base;

namespace EstacionaFacil.Infra.Data.Repositories
{
    public class VeiculoRepository : EntidadeDominioRepository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(EstacionaFacilDbContext contexto) : base(contexto) { }
    }
}
