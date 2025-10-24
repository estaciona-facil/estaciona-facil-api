using System.Threading.Tasks;

namespace Estacionamento.Domain.Interfaces.Repository.Base
{
    public interface IBaseExcluirRepository<T> : IBaseTransacaoRepository<T> where T : class
    {
        Task<T> Excluir(T obj, bool aplicarAlteracoes);
    }
}
