using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Entities
{
    public class Proprietario : EntidadeDominio<Proprietario> 
    {
        public Proprietario(string nome)
        {
            Nome = nome;
        }

        public string? Nome { get; set; }
    }
}
