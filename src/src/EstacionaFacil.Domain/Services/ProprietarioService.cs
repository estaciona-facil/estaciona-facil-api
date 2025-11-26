using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Repositories;
using EstacionaFacil.Domain.Interfaces.Services;
using EstacionaFacil.Domain.Services.Base;
using EstacionaFacil.Domain.Utils;
using EstacionaFacil.Domain.Validations;

namespace EstacionaFacil.Domain.Services
{
    public class ProprietarioService : EntidadeDominioService<Proprietario>, IProprietarioService
    {
        public ProprietarioService(IProprietarioRepository repository, NegocioService negocioService) : base(repository, negocioService) 
        {
        }
        public override Task<Proprietario> AdicionarAsync(Proprietario entidade)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new ProprietarioValidator());
            return base.AdicionarAsync(entidade);
        }

        public override Task<Proprietario> AtualizarAsync(Proprietario entidade)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new ProprietarioValidator());
            return base.AtualizarAsync(entidade);
        }
    }
}
