using EstacionaFacil.Domain.Entities.Base;
using EstacionaFacil.Domain.Interfaces.Repositories.Base;
using EstacionaFacil.Domain.Interfaces.Services.Base;

namespace EstacionaFacil.Domain.Services.Base
{
    public abstract class EntidadeDominioService<T> : Service<T>, IService<T> where T : EntidadeDominio<T>
    {
        private readonly IEntidadeDominioRepository<T> _entidadeDominioRepository;
        public EntidadeDominioService(IEntidadeDominioRepository<T> repository, NegocioService negocioService) : base(repository, negocioService)
        {
            _entidadeDominioRepository = repository;
        }

        public virtual Task<T?> ObterPorIdAsync(Guid id)
        {
            return _entidadeDominioRepository.ObterPorIdAsync(id);
        }
    }
}
