using FluentValidation;
using EstacionaFacil.Domain.Entities;

namespace EstacionaFacil.Domain.Validations
{
    public sealed class VeiculoValidator : AbstractValidator<Veiculo>
    {
        public VeiculoValidator() 
        {
            RuleFor(x => x.Placa)
                .NotEmpty().WithMessage("Informação de Placa vazia, mal formatada ou inválida.")
                .Length(8).WithMessage("Informação de Placa deve conter 8 caracteres.")
                .Matches(@"^[A-Z]{3}-(?:\d[A-Z]\d{2}|\d{4})$").WithMessage("Informação de Placa deve estar no formato XXX-XXXX.");
        }
    }
}
