using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Repositories;
using EstacionaFacil.Domain.Interfaces.Services;
using EstacionaFacil.Domain.Services.Base;
using EstacionaFacil.Domain.Utils;
using EstacionaFacil.Domain.Validations;

namespace EstacionaFacil.Domain.Services
{
    public class MarcaService : EntidadeDescricaoService<Marca>, IMarcaService
    {
        public MarcaService(IMarcaRepository repository, NegocioService negocioService) : base(repository, negocioService) 
        {
        }

        public override Task<Marca> AdicionarAsync(Marca entidade)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new MarcaValidator());
            return base.AdicionarAsync(entidade);
        }

        public override Task<Marca> AtualizarAsync(Marca entidade)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new MarcaValidator());
            return base.AtualizarAsync(entidade);
        }
    }
}
