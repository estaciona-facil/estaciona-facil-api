using EstacionaFacil.Domain.Entities.Base;
using EstacionaFacil.Domain.Interfaces.Repositories.Base;
using EstacionaFacil.Domain.Interfaces.Services.Base;

namespace EstacionaFacil.Domain.Services.Base
{
    public abstract class EntidadeRelacionamentoService<T> : Service<T>, IService<T> where T : EntidadeRelacionamento<T>
    {
        public EntidadeRelacionamentoService(IRepository<T> repository, NegocioService negocioService) : base(repository, negocioService) { }
    }
}
