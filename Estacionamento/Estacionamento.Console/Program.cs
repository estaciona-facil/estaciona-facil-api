using Estacionamento.Domain.Entidades;
using Estacionamento.Domain.Entidades.Estacionamento;
using Estacionamento.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace Estacionamento.App
{
    class Program
    {
        private static List<Veiculo> veiculos = new List<Veiculo>();
        private static List<EstacionamentoBasico> acessos = new List<EstacionamentoBasico>();

        static void Main(string[] args)
        {
            String opcaoEscolhida;

            do
            {
                Console.WriteLine("Bem-vindo ao programa de estacionamento, escolha uma opcao:");
                Console.WriteLine("1 - Cadastrar novo veiculo");
                Console.WriteLine("2 - Cadastrar novo acesso a veiculo existente");
                Console.WriteLine("0 - Sair");
                opcaoEscolhida = Console.ReadLine();

                switch (opcaoEscolhida)
                {
                    case "1":
                        cadastroVeiculo();
                        break;
                    case "2":
                        novoAcesso();
                        break;
                }
            } while (!opcaoEscolhida.Equals("0"));

            Console.WriteLine("Faturamento da sessão: R$ %.2f", EstacionamentoBasico.Faturamento);
        }



        public static Proprietario cadastroProprietario(Veiculo v)
        {
            String nome, endereco, celular, telefone, cnh;

            try
            {
                Console.WriteLine("Nome:");
                nome = Console.ReadLine();

                Console.WriteLine("Endereco:");
                endereco = Console.ReadLine();

                Console.WriteLine("Celular:");
                celular = Console.ReadLine();

                Console.WriteLine("Telefone");
                telefone = Console.ReadLine();

                Console.WriteLine("CNH");
                cnh = Console.ReadLine();

                if (nome.Equals(""))
                    throw new DadosPessoaisIncompletosException("Campo vazio: Nome");
                if (endereco.Equals(""))
                    throw new DadosPessoaisIncompletosException("Campo vazio: Endereco");
                if (celular.Equals(""))
                    throw new DadosPessoaisIncompletosException("Campo vazio: Celular");
                if (telefone.Equals(""))
                    throw new DadosPessoaisIncompletosException("Campo vazio: Telefone");
                if (cnh.Equals(""))
                    throw new DadosPessoaisIncompletosException("Campo vazio: CNH");
            }
            catch (DadosPessoaisIncompletosException e)
            {
                Console.WriteLine("Por favor, preencha todos os campos. " + e.Message);
                return null;
            }

            Proprietario proprietario = new Proprietario(nome, endereco, celular, telefone, int.Parse(cnh));
            return proprietario;
        }

        public static void cadastroVeiculo()
        {
            String marca, modelo, placa;

            try
            {
                Console.WriteLine("Marca:");
                marca = Console.ReadLine();

                Console.WriteLine("Modelo:");
                modelo = Console.ReadLine();

                Console.WriteLine("Placa:");
                placa = Console.ReadLine();

                if (marca.Equals(""))
                    throw new DadosVeiculosIncompletosException("Campo vazio: marca");
                if (modelo.Equals(""))
                    throw new DadosVeiculosIncompletosException("Campo vazio: modelo");
                if (placa.Equals(""))
                    throw new DadosVeiculosIncompletosException("Campo vazio: placa");
            }
            catch (DadosVeiculosIncompletosException e)
            {
                Console.WriteLine("Por favor, preencha todos os campos. " + e.Message);
                return;
            }

            Veiculo veiculo = new Veiculo(marca, modelo, placa);

            Console.WriteLine("É veiculo de mensalidade? S/N");
            String resposta = Console.ReadLine().ToUpper();

            switch (resposta)
            {
                case "N":
                    break;
                case "S":
                    veiculo.DefinirProprietario(cadastroProprietario(veiculo));
                    break;
                default:
                    Console.WriteLine("Escreva S ou N!");
                    break;
            }

            veiculos.Add(veiculo);

            return;
        }

        public static Veiculo procurarVeiculo(String placa)
        {
            foreach(var veiculo in veiculos)
            {
                if (veiculo.Placa.Equals(placa)) return veiculo;
            }

            return null;
        }

        public static void novoAcesso()
        {

            // escolher veiculo
            Console.WriteLine("Digite a placa do veículo:");
            String placa = Console.ReadLine();
            Veiculo veiculo = procurarVeiculo(placa);
            if (veiculo == null)
            {
                Console.WriteLine("Placa não encontrada");
                return;
            }

            try
            {
                Console.WriteLine("Data de Acesso:");
                if(DateTime.TryParse(Console.ReadLine(), out DateTime dataAcesso))
                    throw new DadosAcessoIncompletosException("Campo vazio: Data de Acesso");


                Console.WriteLine("Hora de Entrada(hh:mm):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dataHoraEntrada))
                    throw new DadosAcessoIncompletosException("Campo vazio: Hora de entrada");

                Console.WriteLine("Hora de Saida(hh:mm):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dataHoraSaida))
                    throw new DadosAcessoIncompletosException("Campo vazio: Hora de saida");

                var estadia = (decimal)(dataHoraSaida - dataHoraEntrada).TotalSeconds;

                if ((dataHoraEntrada.Hour >= 20) && (dataHoraEntrada.Hour <= 6))
                    throw new EstacionamentoFechadoException("Horario de entrada");
                if ((dataHoraSaida.Hour >= 20) && (dataHoraSaida.Hour <= 6))
                    throw new EstacionamentoFechadoException("Horario de sai­da");
                if (dataHoraSaida.Hour * 60 + dataHoraSaida.Minute - dataHoraEntrada.Hour * 60 + dataHoraEntrada.Minute <= 0)
                    throw new PeriodoInvalidoException("Possivel pernoite");




                EstacionamentoBasico estacionamento;
                if (veiculo.Proprietario != null)
                {
                    // Estacionamento mensalista
                    estacionamento = new EstacionamentoMensalista(dataAcesso, dataHoraEntrada, dataHoraSaida, veiculo);

                }
                else if (dataHoraSaida.Hour * 60 + dataHoraSaida.Minute - dataHoraEntrada.Hour * 60 + dataHoraEntrada.Minute <= 0)
                {
                    // Estacionamento pernoite
                    estacionamento = new EstacionamentoPernoite(dataAcesso, dataHoraEntrada, dataHoraSaida, veiculo);

                }
                else if (estadia / 60 >= 9)
                {
                    // Estacionamento di�ria
                    estacionamento = new EstacionamentoDiario(dataAcesso, dataHoraEntrada, dataHoraSaida, veiculo);

                }
                else
                {
                    // Estacionamento normal
                    estacionamento = new EstacionamentoBasico(dataAcesso, dataHoraEntrada, dataHoraSaida, veiculo);

                }

                acessos.Add(estacionamento);
                Console.WriteLine("Valor do Estacionamento: R$ %.2f \n", estacionamento.ValorEstacionamento);
            }
            catch (DadosAcessoIncompletosException e)
            {
                Console.WriteLine("Por favor, preencha todos os campos. " + e.Message);
                return;
            }
            catch (EstacionamentoFechadoException e)
            {
                Console.WriteLine("Hor�rio inv�lido, o seguinte hor�rio foi inserido enquanto o estacionamento estava fechado: " + e.Message);
                return;
            }
            catch (PeriodoInvalidoException e)
            {
                Console.WriteLine("Hor�rio registrado indica pernoite? S/N");
                String resposta = Console.ReadLine().ToUpper();
                switch (resposta)
                {
                    case "N":
                        Console.WriteLine("Periodo de estadia invalido");
                        return;
                    case "S":
                        break;
                }
            }
        }
    }
}
