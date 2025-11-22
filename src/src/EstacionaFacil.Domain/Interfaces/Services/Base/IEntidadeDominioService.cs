using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Interfaces.Services.Base
{
    public interface IEntidadeDominioService<T>: IService<T> where T : EntidadeDominio
    {
        Task<T?> ObterPorIdAsync(Guid id);
    }
}
