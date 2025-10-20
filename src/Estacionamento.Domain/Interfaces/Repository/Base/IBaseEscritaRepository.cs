namespace Estacionamento.Domain.Interfaces.Repository.Base
{
    public interface IBaseEscritaRepository<T> : IBaseAdicionarRepository<T> where T : class
    {
    }
}
