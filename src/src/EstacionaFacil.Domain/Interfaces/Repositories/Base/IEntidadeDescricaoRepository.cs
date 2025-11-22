using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Interfaces.Repositories.Base
{
    public interface IEntidadeDescricaoRepository<T> : IRepository<T> where T : EntidadeDescricao
    {
        Task<T?> ObterPorIdAsync(int id);
    }
}
