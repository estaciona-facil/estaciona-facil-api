using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Interfaces.Services.Base
{
    public interface IEntidadeDescricaoService<T> : IService<T> where T : EntidadeDescricao<T>
    {
        Task<T?> ObterPorIdAsync(int id);
    }
}
