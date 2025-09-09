using System;

namespace Estacionamento.Domain
{
    public class EstacionamentoDiario : Estacionamento
    {
        public EstacionamentoDiario(String dataAcesso, String horaEntrada, String horaSaida, Veiculo v)
            : base(dataAcesso, horaEntrada, horaSaida, v) { }

        
        public override void calcularPreco()
        {
            String[] HEsplit = this.hora_entrada.Split(":");
            int horaEntrada = int.Parse(HEsplit[0]);
            int minutoEntrada = int.Parse(HEsplit[1]);
            // Guardar hora e minuto de saida

            String[] HSsplit = this.hora_saida.Split(":");
            int horaSaida = int.Parse(HSsplit[0]);
            int minutoSaida = int.Parse(HSsplit[1]);

            // Converte para apenas minutos
            int tin = horaEntrada * 60 + minutoEntrada;
            int tout = horaSaida * 60 + minutoSaida;

            // Calcula o tempo de estadia (em minutos)
            int estadia = tout - tin; // AQUI ESTÁ O TEMPO DE ESTADIA EM MINUTOS

            float valorMinuto = 0.2f;
            valorEstacionamento = 110;
            valorEstacionamento += calculoEstadia(estadia - 9 * 60, valorMinuto);
            faturamento += valorEstacionamento;
        }
    }
}
