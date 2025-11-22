using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Interfaces.Repositories.Base
{
    public interface IEntidadeDominioRepository<T> : IRepository<T> where T : EntidadeDominio
    {
        Task<T?> ObterPorIdAsync(Guid id);
    }
}
