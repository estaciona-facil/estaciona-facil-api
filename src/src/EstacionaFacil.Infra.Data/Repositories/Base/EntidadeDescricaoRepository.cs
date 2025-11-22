using EstacionaFacil.Infra.Data.Context;
using EstacionaFacil.Domain.Entities.Base;
using EstacionaFacil.Domain.Interfaces.Repositories.Base;
namespace EstacionaFacil.Infra.Data.Repositories.Base
{
    public abstract class EntidadeDescricaoRepository<T> : Repository<T>, IDisposable, IEntidadeDescricaoRepository<T> where T : EntidadeDescricao
    {
        protected EntidadeDescricaoRepository(DomainDbContext contexto) : base(contexto) { }

        public async Task<T?> ObterPorIdAsync(int id)
        {
            return await Entidades.FindAsync(id);
        }
    }
}
