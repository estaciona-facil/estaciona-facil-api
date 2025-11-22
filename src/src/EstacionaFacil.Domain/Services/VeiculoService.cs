using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Services.Base;
using EstacionaFacil.Domain.Interfaces.Repositories;
using EstacionaFacil.Domain.Interfaces.Services;

namespace EstacionaFacil.Domain.Services
{
    public class VeiculoService : EntidadeDominioService<Veiculo>, IVeiculoService
    {
        public VeiculoService(IVeiculoRepository repository) : base(repository) 
        {
        }
    }
}
