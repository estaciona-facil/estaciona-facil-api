using System;

namespace Estacionamento.Domain
{
    public class EstacionamentoMensalista : Estacionamento
    {
        public EstacionamentoMensalista(String dataAcesso, String horaEntrada, String horaSaida, Veiculo v)
            : base(dataAcesso, horaEntrada, horaSaida, v) { }

        
        public override void calcularPreco()
        {
            valorEstacionamento = 500;
            faturamento += valorEstacionamento;
        }
    }
}
