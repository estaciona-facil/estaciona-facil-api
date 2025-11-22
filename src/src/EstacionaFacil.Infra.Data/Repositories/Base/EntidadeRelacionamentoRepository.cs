using EstacionaFacil.Infra.Data.Context;
using EstacionaFacil.Domain.Entities.Base;
using EstacionaFacil.Domain.Interfaces.Repositories.Base;
namespace EstacionaFacil.Infra.Data.Repositories.Base
{
    public abstract class EntidadeRelacionamentoRepository<T> : Repository<T>, IDisposable, IEntidadeRelacionamentoRepository<T> where T : EntidadeRelacionamento
    {
        protected EntidadeRelacionamentoRepository(DomainDbContext contexto) : base(contexto) { }
    }
}
