using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Interfaces.Services.Base
{
    public interface IEntidadeRelacionamentoService<T> : IService<T> where T : EntidadeRelacionamento
    {
    }
}
