using FluentValidation;
using EstacionaFacil.Domain.Entities;

namespace EstacionaFacil.Domain.Validations
{
    public sealed class ProprietarioValidator : AbstractValidator<Proprietario>
    {
        public ProprietarioValidator() 
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Informação de Nome vazia, mal formatada ou inválida.")
                .MinimumLength(3).WithMessage("Informação de Nome deve conter no entre 3 e 200 caracteres.")
                .MaximumLength(200).WithMessage("Informação de Nome deve conter no entre 3 e 200 caracteres.");
        }
    }
}
