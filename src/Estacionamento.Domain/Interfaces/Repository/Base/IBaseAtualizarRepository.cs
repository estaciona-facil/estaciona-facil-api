using System.Threading.Tasks;

namespace Estacionamento.Domain.Interfaces.Repository.Base
{
    public interface IBaseAtualizarRepository<T> : IBaseTransacaoRepository<T> where T : class
    {
        Task<T> Atualizar(T obj, bool aplicarAlteracoes);
    }
}
