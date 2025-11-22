using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Entities
{
    public class Modelo : EntidadeDescricao 
    {
        public int MarcaId { get; set; }
        public Marca? Marca { get; set; } = null;

        public override void LimparRelacionamentos()
        {
            Marca = null;
        }
    }
}
