using System;

namespace Estacionamento.Domain.Entidades.Estacionamento
{
    public class EstacionamentoPernoite : EstacionamentoBasico
    {
        public EstacionamentoPernoite(DateTime dataAcesso, DateTime horaEntrada, DateTime? horaSaida, Veiculo veiculo)
            : base(dataAcesso, horaEntrada, horaSaida, veiculo) { }

        
        public override void CalcularPreco()
        {
            var valorMinuto = 0.5M;

            DefinirValorEstacionamento(
                30 +
                CalculoValorEstadiaPorMinuto(60 * 20 - DataHoraEntrada.Ticks, valorMinuto) +
                CalculoValorEstadiaPorMinuto(DataHoraSaida.Value.Ticks - 60 * 6, valorMinuto) 
            );

            AdicionarValorFaturamento(ValorEstacionamento);
        }
    }
}
