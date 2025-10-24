namespace Estacionamento.Domain.Interfaces.Repository.Base
{
    public interface IBaseEscritaRepository<T> : IBaseAdicionarRepository<T>, IBaseAtualizarRepository<T>, IBaseExcluirRepository<T> where T : class
    {
    }
}
