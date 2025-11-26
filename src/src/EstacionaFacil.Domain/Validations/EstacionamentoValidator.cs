using FluentValidation;
using EstacionaFacil.Domain.Entities;

namespace EstacionaFacil.Domain.Validations
{
    public sealed class EstacionamentoValidator : AbstractValidator<Estacionamento>
    {
        public EstacionamentoValidator() 
        {
            RuleFor(x => x.MtrValorHora)
                .NotNull().WithMessage("Informação de Valor Hora vazia, mal formatada ou inválida.")
                .GreaterThan(0).WithMessage("Informação de Valor Hora deve ser maior que zero.");
        }
    }
}
