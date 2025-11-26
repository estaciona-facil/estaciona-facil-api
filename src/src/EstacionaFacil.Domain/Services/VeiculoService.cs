using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Repositories;
using EstacionaFacil.Domain.Interfaces.Services;
using EstacionaFacil.Domain.Services.Base;
using EstacionaFacil.Domain.Utils;
using EstacionaFacil.Domain.Validations;

namespace EstacionaFacil.Domain.Services
{
    public class VeiculoService : EntidadeDominioService<Veiculo>, IVeiculoService
    {
        public VeiculoService(IVeiculoRepository repository, NegocioService negocioService) : base(repository, negocioService) 
        {
        }
        public override Task<Veiculo> AdicionarAsync(Veiculo entidade)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new VeiculoValidator());
            return base.AdicionarAsync(entidade);
        }

        public override Task<Veiculo> AtualizarAsync(Veiculo entidade)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new VeiculoValidator());
            return base.AtualizarAsync(entidade);
        }
    }
}
