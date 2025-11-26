using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Repositories;
using EstacionaFacil.Domain.Interfaces.Services;
using EstacionaFacil.Domain.Services.Base;
using EstacionaFacil.Domain.Utils;
using EstacionaFacil.Domain.Validations;

namespace EstacionaFacil.Domain.Services
{
    public class ModeloService : EntidadeDescricaoService<Modelo>, IModeloService
    {
        public ModeloService(IModeloRepository repository, NegocioService negocioService) : base(repository, negocioService) 
        {
        }

        public override Task<Modelo> AdicionarAsync(Modelo entidade)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new ModeloValidator());
            return base.AdicionarAsync(entidade);
        }

        public override Task<Modelo> AtualizarAsync(Modelo entidade)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new ModeloValidator());
            return base.AtualizarAsync(entidade);
        }
    }
}
