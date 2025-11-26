using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Interfaces.Services.Base
{
    public interface IEntidadeDominioService<T>: IService<T> where T : EntidadeDominio<T>
    {
        Task<T?> ObterPorIdAsync(Guid id);
    }
}
