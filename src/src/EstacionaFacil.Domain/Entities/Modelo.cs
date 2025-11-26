using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Entities
{
    public class Modelo : EntidadeDescricao<Modelo> 
    {
        public int MarcaId { get; set; }
        public Marca? Marca { get; set; } = null;

        public Modelo() : base() { }
        public Modelo(string descricao, int marcaId) : base(descricao) 
        {
            MarcaId = marcaId; 
        }

        public override void LimparRelacionamentos()
        {
            Marca = null;
        }
    }
}
