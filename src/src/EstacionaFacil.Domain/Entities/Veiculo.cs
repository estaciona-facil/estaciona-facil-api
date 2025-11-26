using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Entities
{
    public class Veiculo : EntidadeDominio<Veiculo> 
    {
        public Veiculo(string placa) 
        {
            Placa = placa;
        }

        public string? Placa { get; set; }

        public int? ModeloId { get; set; } = null;
        public Guid? ProprietarioId { get; set; } = null;

        public Modelo? Modelo { get; set; } = null;
        public Proprietario? Proprietario { get; set; } = null;

        public override void LimparRelacionamentos()
        {
            Modelo = null;
            Proprietario = null;
        }
    }
}
