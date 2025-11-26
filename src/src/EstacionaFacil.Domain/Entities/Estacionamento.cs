using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Entities
{
    public class Estacionamento : EntidadeDominio<Estacionamento>
    {
        public Estacionamento() : base() { }
        public Estacionamento(string nome, decimal mtrValorHora, int? tolerancia = null) : base()
        {
            Nome = nome;
            MtrValorHora = mtrValorHora;
            MinutosTolerancia = tolerancia;
        }

        public string? Nome { get; set; }
        public decimal? MtrValorHora { get; set; }
        public int? MinutosTolerancia { get; set; }

        public Guid? EnderecoId { get; set; } = null;
        public Endereco? Endereco { get; set; } = null;
    }
}
