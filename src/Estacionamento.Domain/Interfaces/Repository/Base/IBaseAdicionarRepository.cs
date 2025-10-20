using System.Threading.Tasks;

namespace Estacionamento.Domain.Interfaces.Repository.Base
{
    public interface IBaseAdicionarRepository<T> : IBaseTransacaoRepository<T> where T : class
    {
        Task<T> Adicionar(T obj, bool aplicarAlteracoes);
    }
}
