using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Entities
{
    public class Estacionamento : EntidadeDominio<Estacionamento>
    {
        public Estacionamento() : base() { }
        public Estacionamento(decimal mtrValorHora, int? tolerancia = null) : base()
        {
            MtrValorHora = mtrValorHora;
            MinutosTolerancia = tolerancia;
        }

        public decimal? MtrValorHora { get; set; }
        public int? MinutosTolerancia { get; set; }

        public Guid? EnderecoId { get; set; } = null;
        public Endereco? Endereco { get; set; } = null;
    }
}
