using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Validations.Base;

namespace EstacionaFacil.Domain.Validations
{
    public sealed class MarcaValidator : EntidadeDescricaoValidator<Marca> 
    {
        public MarcaValidator() : base() { }
    }
}
