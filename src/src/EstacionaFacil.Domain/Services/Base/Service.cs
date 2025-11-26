using EstacionaFacil.Domain.Entities.Base;
using EstacionaFacil.Domain.Interfaces.Repositories.Base;
using EstacionaFacil.Domain.Interfaces.Services.Base;
using System.Linq.Expressions;

namespace EstacionaFacil.Domain.Services.Base
{
    public abstract class Service<T> : IService<T> where T : Entidade<T>
    {
        protected IRepository<T> _repository;
        protected readonly NegocioService _negocioService;

        public Service(IRepository<T> repository, NegocioService negocioService) 
        {
            _repository = repository;
            _negocioService = negocioService;
        }

        public virtual Task<T> AdicionarAsync(T entidade)
        {
            return _repository.AdicionarAsync(entidade);
        }

        public virtual Task<T> AtualizarAsync(T entidade)
        {
            return _repository.AtualizarAsync(entidade);
        }

        public virtual Task<T> ExcluirAsync(T entidade)
        {
            return _repository.ExcluirAsync(entidade);
        }

        public virtual Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> where)
        {
            return _repository.BuscarAsync(where);
        }

        public virtual Task<IEnumerable<T>> ObterTodosAsync()
        {
            return _repository.ObterTodosAsync();
        }
    }
}
