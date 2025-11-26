using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Repositories;
using EstacionaFacil.Domain.Interfaces.Services;
using EstacionaFacil.Domain.Services.Base;
using EstacionaFacil.Domain.Utils;
using EstacionaFacil.Domain.Validations;

namespace EstacionaFacil.Domain.Services
{
    public class EstacionamentoService : EntidadeDominioService<Estacionamento>, IEstacionamentoService
    {
        public EstacionamentoService(IEstacionamentoRepository repository, NegocioService negocioService) : base(repository, negocioService) 
        {
        }

        public override Task<Estacionamento> AdicionarAsync(Estacionamento entidade)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new EstacionamentoValidator());
            return base.AdicionarAsync(entidade);
        }

        public override Task<Estacionamento> AtualizarAsync(Estacionamento entidade)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new EstacionamentoValidator());
            return base.AtualizarAsync(entidade);
        }
    }
}
