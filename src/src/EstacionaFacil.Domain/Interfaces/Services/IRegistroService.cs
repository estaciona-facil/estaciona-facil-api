using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Services.Base;

namespace EstacionaFacil.Domain.Interfaces.Services
{
    public interface IRegistroService : IEntidadeRelacionamentoService<Registro> 
    {
        Task<Registro> RegistrarEventoPorPlacaAsync(Guid estacionamentoId, string placa);
        Task<Registro> ObterPelaPlacaAsync(string placa);
    }
}
