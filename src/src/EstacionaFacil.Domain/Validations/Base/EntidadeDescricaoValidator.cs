using FluentValidation;
using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Validations.Base
{
    public abstract class EntidadeDescricaoValidator<T> : AbstractValidator<T> where T : EntidadeDescricao<T>
    {
        public EntidadeDescricaoValidator() 
        {
            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("Informação de Descricao vazia, mal formatada ou inválida.")
                .MinimumLength(5).WithMessage("Informação de Descricao deve conter entre 5 e 150 caracteres.")
                .MaximumLength(150).WithMessage("Informação de Descricao deve conter entre 5 e 150 caracteres.");
        }
    }
}
