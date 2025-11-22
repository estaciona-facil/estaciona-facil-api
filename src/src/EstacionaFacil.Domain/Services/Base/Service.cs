using EstacionaFacil.Domain.Entities.Base;
using EstacionaFacil.Domain.Interfaces.Repositories.Base;
using EstacionaFacil.Domain.Interfaces.Services.Base;
using System.Linq.Expressions;

namespace EstacionaFacil.Domain.Services.Base
{
    public abstract class Service<T> : IService<T> where T : Entidade
    {
        protected IRepository<T> _repository;

        public Service(IRepository<T> repository) 
        {
            _repository = repository;
        }

        public Task<T> AdicionarAsync(T entidade)
        {
            return _repository.AdicionarAsync(entidade);
        }

        public Task<T> AtualizarAsync(T entidade)
        {
            return _repository.AtualizarAsync(entidade);
        }

        public Task<T> ExcluirAsync(T entidade)
        {
            return _repository.ExcluirAsync(entidade);
        }

        public Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> where)
        {
            return _repository.BuscarAsync(where);
        }

        public Task<IEnumerable<T>> ObterTodosAsync()
        {
            return _repository.ObterTodosAsync();
        }
    }
}
