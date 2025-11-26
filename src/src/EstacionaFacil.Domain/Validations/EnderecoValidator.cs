using FluentValidation;
using EstacionaFacil.Domain.Entities;

namespace EstacionaFacil.Domain.Validations
{
    public sealed class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator() 
        {
            RuleFor(x => x.Cep)
                .NotNull().WithMessage("Informação de Cep vazia, mal formatada ou inválida.");
            RuleFor(x => x.Cidade)
                .NotNull().WithMessage("Informação de Cidade vazia, mal formatada ou inválida.");
            RuleFor(x => x.Bairro)
                .NotNull().WithMessage("Informação de Bairro vazia, mal formatada ou inválida.");
            RuleFor(x => x.Logradouro)
                .NotNull().WithMessage("Informação de Logradouro vazia, mal formatada ou inválida.");
            RuleFor(x => x.Numero)
                .NotNull().WithMessage("Informação de Numero vazia, mal formatada ou inválida.");
            RuleFor(x => x.Complemento)
                .NotNull().WithMessage("Informação de Complemento vazia, mal formatada ou inválida.");
        }
    }
}
