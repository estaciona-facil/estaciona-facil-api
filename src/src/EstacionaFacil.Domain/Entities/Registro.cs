using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Entities
{
    public class Registro : EntidadeRelacionamento
    {
        public Registro(Guid veiculoId, Guid estacionamentoId)
        {
            VeiculoId = veiculoId;
            EstacionamentoId = estacionamentoId;
        }

        public DateTime? DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }

        public Guid VeiculoId { get; set; }
        public Guid EstacionamentoId { get; set; }

        public Veiculo? Veiculo { get; set; } = null;
        public Estacionamento? Estacionamento { get; set; } = null;

        public double? TempoEstacionadoEmMinutos()
        {
            if (!DataSaida.HasValue || !DataEntrada.HasValue) return null;
            return (DataSaida.Value - DataEntrada.Value).TotalMinutes;
        }

        public void RegistrarEntrada() { DataEntrada = DateTime.UtcNow; }
        public void RegistrarSaida() { DataSaida = DateTime.UtcNow; }

        public override void LimparRelacionamentos()
        {
            Veiculo = null;
            Estacionamento = null;
        }
    }
}
