using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Interfaces.Repositories.Base
{
    public interface IEntidadeRelacionamentoRepository<T> : IRepository<T> where T : EntidadeRelacionamento<T>
    {
    }
}
