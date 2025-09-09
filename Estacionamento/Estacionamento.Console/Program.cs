using Estacionamento.Domain;
using System;
using System.Collections.Generic;
using EstacionamentoModel = Estacionamento.Domain.Estacionamento;

namespace Estacionamento.App
{
    class Program
    {
        private static List<Veiculo> veiculos = new List<Veiculo>();
        private static List<Proprietario> proprietarios = new List<Proprietario>();
        private static List<EstacionamentoModel> acessos = new List<EstacionamentoModel>();

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

            Console.WriteLine("Faturamento da sessão: R$ %.2f", EstacionamentoModel.getFaturamento());
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

            Proprietario o_Proprietario = new Proprietario(nome, endereco, int.Parse(celular), int.Parse(telefone), int.Parse(cnh));
            return o_Proprietario;
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

            Veiculo o_Veiculo = new Veiculo(marca, modelo, placa);

            Console.WriteLine("É veiculo de mensalidade? S/N");
            String resposta = Console.ReadLine().ToUpper();

            switch (resposta)
            {
                case "N":
                    break;
                case "S":
                    Proprietario p = cadastroProprietario(o_Veiculo);
                    o_Veiculo.setProprietario(p);
                    break;
                default:
                    Console.WriteLine("Escreva S ou N!");
                    break;
            }

            veiculos.Add(o_Veiculo);

            return;
        }

        public static Veiculo procurarVeiculo(String placa)
        {
            foreach(var veiculo in veiculos)
            {
                if (veiculo.getPlaca().Equals(placa)) return veiculo;
            }

            return null;
        }

        public static void novoAcesso()
        {

            // escolher veiculo
            Console.WriteLine("Digite a placa do veículo:");
            String placa = Console.ReadLine();
            Veiculo v = procurarVeiculo(placa);
            if (v == null)
            {
                Console.WriteLine("Placa não encontrada");
                return;
            }

            String DataAcesso = null, HoraEntrada = null, HoraSaida = null;
            int tin = 0, tout = 0, estadia = 0;

            try
            {
                Console.WriteLine("Data de Acesso:");
                DataAcesso = Console.ReadLine();

                Console.WriteLine("Hora de Entrada(hh:mm):");
                HoraEntrada = Console.ReadLine();

                Console.WriteLine("Hora de Saida(hh:mm):");
                HoraSaida = Console.ReadLine();

                if (DataAcesso.Equals(""))
                    throw new DadosAcessoIncompletosException("Campo vazio: Data de Acesso");
                if (HoraEntrada.Equals(""))
                    throw new DadosAcessoIncompletosException("Campo vazio: Hora de entrada");
                if (HoraSaida.Equals(""))
                    throw new DadosAcessoIncompletosException("Campo vazio: Hora de saida");

                // Dividindo horas e minutos em inteiros
                String[] HEsplit = HoraEntrada.Split(":");
                int horaEntrada = int.Parse(HEsplit[0]);
                int minutoEntrada = int.Parse(HEsplit[1]);
                String[] HSsplit = HoraSaida.Split(":");
                int horaSaida = int.Parse(HSsplit[0]);
                int minutoSaida = int.Parse(HSsplit[1]);

                // Converte para apenas minutos
                tin = horaEntrada * 60 + minutoEntrada;
                tout = horaSaida * 60 + minutoSaida;

                // Calcula o tempo de estadia (em minutos)
                estadia = tout - tin;

                if ((horaEntrada >= 20) && (horaEntrada <= 6))
                    throw new EstacionamentoFechadoException("Horario de entrada");
                if ((horaSaida >= 20) && (horaSaida <= 6))
                    throw new EstacionamentoFechadoException("Horario de sai­da");
                if (horaSaida * 60 + minutoSaida - horaEntrada * 60 + minutoEntrada <= 0)
                    throw new PeriodoInvalidoException("Possivel pernoite");

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

            EstacionamentoModel o_Estacionamento;
            if (v.getProprietario() != null)
            {
                // Estacionamento mensalista
                o_Estacionamento = new EstacionamentoMensalista(DataAcesso, HoraEntrada, HoraSaida, v);

            }
            else if (tin >= tout)
            {
                // Estacionamento pernoite
                o_Estacionamento = new EstacionamentoPernoite(DataAcesso, HoraEntrada, HoraSaida, v);

            }
            else if (estadia / 60 >= 9)
            {
                // Estacionamento di�ria
                o_Estacionamento = new EstacionamentoDiario(DataAcesso, HoraEntrada, HoraSaida, v);

            }
            else
            {
                // Estacionamento normal
                o_Estacionamento = new EstacionamentoModel(DataAcesso, HoraEntrada, HoraSaida, v);

            }

            acessos.Add(o_Estacionamento);
            Console.WriteLine("Valor do Estacionamento: R$ %.2f \n", o_Estacionamento.getValorEstacionamento());
        }
    }
}
