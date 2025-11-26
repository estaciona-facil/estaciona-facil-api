using FluentValidation;
using EstacionaFacil.Domain.Entities;

namespace EstacionaFacil.Domain.Validations
{
    public sealed class RegistroValidator : AbstractValidator<Registro>
    {
        public RegistroValidator() 
        {
            RuleFor(x => x.VeiculoId)
                .NotEqual(Guid.Empty).WithMessage("Identificador do veículo vazia, mal formatada ou inválida.");

            RuleFor(x => x.EstacionamentoId)
                .NotEqual(Guid.Empty).WithMessage("Identificador do estacionamento vazia, mal formatada ou inválida.");

            RuleFor(x => x.DataEntrada)
               .NotNull().WithMessage("Informação de Data Entrada vazia, mal formatada ou inválida.");

            RuleFor(x => x.DataSaida)
               .GreaterThan(x => x.DataEntrada)
               .WithMessage("Data de Saída deve ser maior que Data Entrada.")
               .When(x => x.DataSaida.HasValue);
        }
    }
}
