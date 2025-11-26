using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Entities
{
    public class Marca : EntidadeDescricao<Marca> 
    { 
        public Marca() : base() { }
        public Marca(string descricao) : base(descricao) { }
    }
}
