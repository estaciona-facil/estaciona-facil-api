using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Repositories;
using EstacionaFacil.Domain.Interfaces.Services;
using EstacionaFacil.Domain.Services.Base;
using EstacionaFacil.Domain.Utils;
using EstacionaFacil.Domain.Validations;

namespace EstacionaFacil.Domain.Services
{
    public class EnderecoService : EntidadeDominioService<Endereco>, IEnderecoService
    {
        public EnderecoService(IEnderecoRepository repository, NegocioService negocioService) : base(repository, negocioService) 
        {
        }

        public override Task<Endereco> AdicionarAsync(Endereco entidade)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new EnderecoValidator());
            return base.AdicionarAsync(entidade);
        }

        public override Task<Endereco> AtualizarAsync(Endereco entidade)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new EnderecoValidator());
            return base.AtualizarAsync(entidade);
        }
    }
}
