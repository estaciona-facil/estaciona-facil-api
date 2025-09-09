using System.Threading.Tasks;

namespace Estacionamento.Domain.Interfaces.Repository.Data
{
    public interface IUnityOfWork
    {
        Task<bool> Commit();
    }
}
