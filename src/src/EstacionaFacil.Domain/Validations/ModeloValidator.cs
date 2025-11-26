using FluentValidation;
using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Validations.Base;

namespace EstacionaFacil.Domain.Validations
{
    public sealed class ModeloValidator : EntidadeDescricaoValidator<Modelo> 
    {
        public ModeloValidator() : base()
        {
            RuleFor(x => x.MarcaId)
                .NotNull().WithMessage("Informação de Marca vazia, mal formatada ou inválida.")
                .NotEqual(0).WithMessage("Informação de Marca vazia, mal formatada ou inválida.");
        }
    }
}
