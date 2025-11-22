using EstacionaFacil.Domain.Entities.Base;
using EstacionaFacil.Domain.Interfaces.Repositories.Base;
using EstacionaFacil.Domain.Interfaces.Services.Base;

namespace EstacionaFacil.Domain.Services.Base
{
    public abstract class EntidadeDescricaoService<T> : Service<T>, IService<T> where T : EntidadeDescricao
    {
        private readonly IEntidadeDescricaoRepository<T> _entidadeDescricaoRepository;
        public EntidadeDescricaoService(IEntidadeDescricaoRepository<T> repository) : base(repository) 
        {
            _entidadeDescricaoRepository = repository;
        }

        public Task<T?> ObterPorIdAsync(int id)
        {
            return _entidadeDescricaoRepository.ObterPorIdAsync(id);
        }
    }
}
