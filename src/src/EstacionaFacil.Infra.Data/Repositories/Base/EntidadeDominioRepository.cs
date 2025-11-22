using EstacionaFacil.Infra.Data.Context;
using EstacionaFacil.Domain.Entities.Base;
using EstacionaFacil.Domain.Interfaces.Repositories.Base;
namespace EstacionaFacil.Infra.Data.Repositories.Base
{
    public abstract class EntidadeDominioRepository<T> : Repository<T>, IDisposable, IEntidadeDominioRepository<T> where T : EntidadeDominio
    {
        protected EntidadeDominioRepository(DomainDbContext contexto) : base(contexto) { }

        public async Task<T?> ObterPorIdAsync(Guid id)
        {
            return await Entidades.FindAsync(id);
        }
    }
}
