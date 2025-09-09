using System;

namespace Estacionamento.Domain.Entidades
{
    public class Proprietario
    {
        public Proprietario(string nome, string endereco, string celular, string telefone, int cnh)
        {
            DefinirNome(nome);
            DefinirCnh(cnh);
            DefinirEndereco(endereco);
            DefinirCelular(celular);
            DefinirTelefone(telefone);
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public long NumeroCarteiraNacionalDeHabilitacao { get; private set; }
        public string Telefone { get; private set; }
        public string Celular { get; private set; }
        public string Endereco { get; private set; }

        public void DefinirNome(string valor)
        {
            this.Nome = valor;
        }

        public void DefinirCnh(long valor)
        {
            this.NumeroCarteiraNacionalDeHabilitacao = valor;
        }

        public void DefinirTelefone(string valor)
        {
            this.Telefone = valor;
        }

        public void DefinirCelular(string valor)
        {
            this.Celular = valor;
        }

        public void DefinirEndereco(string valor)
        {
            this.Endereco = valor;
        }
    }
}
