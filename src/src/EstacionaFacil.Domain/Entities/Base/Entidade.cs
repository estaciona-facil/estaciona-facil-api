using FluentValidation;

namespace EstacionaFacil.Domain.Entities.Base
{
    public abstract class Entidade<T>
    {
        private readonly Guid _entidadeValidavelId = Guid.NewGuid();
        public Guid ObterGuidEntidade() => _entidadeValidavelId;

        private readonly ICollection<AbstractValidator<T>> _validacoes = new List<AbstractValidator<T>>();

        public Entidade<T> AdicionarValidacao(AbstractValidator<T> validacao)
        {
            _validacoes.Add(validacao);
            return this;
        }
        public ICollection<AbstractValidator<T>> ObterValidacoes() => _validacoes;
        public virtual void LimparRelacionamentos() { }
    }
}
