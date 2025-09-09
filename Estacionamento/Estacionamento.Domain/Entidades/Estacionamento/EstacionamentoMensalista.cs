using Estacionamento.Domain.Entidades;
using System;

namespace Estacionamento.Domain.Entidades.Estacionamento
{
    public class EstacionamentoMensalista : EstacionamentoBasico
    {
        public EstacionamentoMensalista(DateTime dataAcesso, DateTime horaEntrada, DateTime? horaSaida, Veiculo veiculo)
            : base(dataAcesso, horaEntrada, horaSaida, veiculo) 
        {
            DefinirValorEstacionamento(500);
        }

        
        public override void CalcularPreco()
        {
            AdicionarValorFaturamento(ValorEstacionamento);
        }
    }
}
