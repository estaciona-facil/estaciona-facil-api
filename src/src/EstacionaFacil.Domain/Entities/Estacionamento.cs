using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Entities
{
    public class Estacionamento : EntidadeDominio<Estacionamento>
    {
        public Estacionamento() : base() { }
        public Estacionamento(decimal mtrValorHora) : base()
        {
            MtrValorHora = mtrValorHora;
        }

        public decimal? MtrValorHora { get; set; }
    }
}
