using EstacionaFacil.Domain.Entities.Base;
using System.Linq.Expressions;

namespace EstacionaFacil.Domain.Interfaces.Repositories.Base
{
    public interface IRepository<T> where T : Entidade<T>
    {
        Task<IEnumerable<T>> ObterTodosAsync();
        Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        Task<T> AdicionarAsync(T entidade);
        Task<T> AtualizarAsync(T entidade);
        Task<T> ExcluirAsync(T entidade);
    }
}
