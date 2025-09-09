using System;

namespace Estacionamento.Domain.Entidades.Estacionamento
{
    public class EstacionamentoBasico
    {
        public EstacionamentoBasico(DateTime dataAcesso, DateTime dataHoraEntrada, DateTime? dataHoraSaida, Veiculo veiculo)
        {
            DefinirDataAcesso(dataAcesso);
            DefinirDataHoraEntrada(dataHoraEntrada);
            DefinirDataHoraSaida(dataHoraSaida);
            DefinirVeiculo(veiculo);

            CalcularPreco();
        }

        public Guid Id { get; private set; }
        public DateTime DataAcesso { get; private set; }
        public DateTime DataHoraEntrada { get; private set; }
        public DateTime? DataHoraSaida { get; private set; }
        public decimal ValorEstacionamento { get; private set; }
        public static decimal Faturamento { get; private set; }

        public virtual Veiculo Veiculo { get; set; }

        public void DefinirDataAcesso(DateTime valor)
        {
            DataAcesso = valor;
        }

        public void DefinirDataHoraEntrada(DateTime valor)
        {
            DataHoraEntrada = valor;
        }

        public void DefinirDataHoraSaida(DateTime? valor)
        {
            DataHoraSaida = valor;
        }

        public void DefinirValorEstacionamento(decimal valor)
        {
            ValorEstacionamento = valor;
        }

        public void DefinirVeiculo(Veiculo valor)
        {
            Veiculo = valor;
        }

        public void AdicionarValorFaturamento(decimal faturamento)
        {
            Faturamento += faturamento;
        }

        public void LimparValorFaturamento()
        {
            Faturamento = 0;
        }

        protected decimal CalculoValorEstadiaPorMinuto(decimal minutosPermanecidos, decimal precoMinuto)
        {
            decimal valorPago = precoMinuto * minutosPermanecidos;

            // Desconto hora
            while (minutosPermanecidos >= 60)
            {
                valorPago -= minutosPermanecidos / 60;
                minutosPermanecidos = minutosPermanecidos / 60;
            }

            // Desconto 15min
            while (minutosPermanecidos >= 15)
            {
                valorPago -= minutosPermanecidos / 15 * 0.5M;
                minutosPermanecidos = minutosPermanecidos / 15;
            }

            return valorPago;
        }

        public virtual void CalcularPreco()
        {
            var valorMinuto = 0.5M;
            var tempoDentroDoEstacionamento = (decimal)(DataHoraSaida - DataHoraEntrada).Value.TotalSeconds;

            DefinirValorEstacionamento(CalculoValorEstadiaPorMinuto(tempoDentroDoEstacionamento, valorMinuto));
            AdicionarValorFaturamento(ValorEstacionamento);
        }
    }
}
