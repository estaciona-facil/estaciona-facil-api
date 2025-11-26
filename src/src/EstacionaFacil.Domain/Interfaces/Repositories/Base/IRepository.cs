using EstacionaFacil.Domain.Entities.Base;
using System.Linq.Expressions;

namespace EstacionaFacil.Domain.Interfaces.Repositories.Base
{
    public interface IRepository<T> where T : Entidade<T>
    {
        Task<IEnumerable<T>> ObterTodosAsync();
        Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> where, string[] includes);
        Task<T> AdicionarAsync(T entidade);
        Task<T> AtualizarAsync(T entidade);
        Task<T> ExcluirAsync(T entidade);
    }
}
