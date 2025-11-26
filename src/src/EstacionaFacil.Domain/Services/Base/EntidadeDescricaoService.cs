using EstacionaFacil.Domain.Entities.Base;
using EstacionaFacil.Domain.Interfaces.Repositories.Base;
using EstacionaFacil.Domain.Interfaces.Services.Base;

namespace EstacionaFacil.Domain.Services.Base
{
    public abstract class EntidadeDescricaoService<T> : Service<T>, IService<T> where T : EntidadeDescricao<T>
    {
        private readonly IEntidadeDescricaoRepository<T> _entidadeDescricaoRepository;
        public EntidadeDescricaoService(IEntidadeDescricaoRepository<T> repository, NegocioService negocioService) : base(repository, negocioService) 
        {
            _entidadeDescricaoRepository = repository;
        }

        public Task<T?> ObterPorIdAsync(int id)
        {
            return _entidadeDescricaoRepository.ObterPorIdAsync(id);
        }
    }
}
