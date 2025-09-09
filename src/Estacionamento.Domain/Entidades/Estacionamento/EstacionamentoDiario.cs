using System;

namespace Estacionamento.Domain.Entidades.Estacionamento
{
    public class EstacionamentoDiario : EstacionamentoBasico
    {
        public EstacionamentoDiario(DateTime dataAcesso, DateTime horaEntrada, DateTime? horaSaida, Veiculo veiculo)
            : base(dataAcesso, horaEntrada, horaSaida, veiculo)
        {
            DefinirValorEstacionamento(110);
        }
        
        public override void CalcularPreco()
        {
            decimal valorMinuto = 0.2M;
            var tempoDentroDoEstacionamento = (decimal)(DataHoraSaida - DataHoraEntrada).Value.TotalSeconds;

            DefinirValorEstacionamento(ValorEstacionamento + CalculoValorEstadiaPorMinuto(tempoDentroDoEstacionamento, valorMinuto));
            AdicionarValorFaturamento(ValorEstacionamento);
        }
    }
}
