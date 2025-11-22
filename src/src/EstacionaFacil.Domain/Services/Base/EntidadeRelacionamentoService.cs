using EstacionaFacil.Domain.Entities.Base;
using EstacionaFacil.Domain.Interfaces.Repositories.Base;
using EstacionaFacil.Domain.Interfaces.Services.Base;
using System.Linq.Expressions;

namespace EstacionaFacil.Domain.Services.Base
{
    public abstract class EntidadeRelacionamentoService<T> : Service<T>, IService<T> where T : EntidadeRelacionamento
    {
        public EntidadeRelacionamentoService(IRepository<T> repository) : base(repository) { }
    }
}
