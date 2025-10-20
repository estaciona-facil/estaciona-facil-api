using Estacionamento.Domain.Entidades;
using Estacionamento.Domain.Interfaces.Repository.Base;

namespace Estacionamento.Domain.Interfaces.Repository
{
    public interface IProprietarioRepository : IBaseEscritaRepository<Proprietario>, IBaseLeituraRepository<Proprietario>
    {
    }
}
