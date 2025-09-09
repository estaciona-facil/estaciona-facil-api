using Estacionamento.Domain.DomainObjects;
using System.Collections.Generic;

namespace Estacionamento.Domain.Entidades
{
    public class Proprietario : Entity, IAggregateRoot
    {
        public Proprietario() { }

        public Proprietario(string nome, string endereco, string celular, string telefone, int cnh) : base()
        {
            DefinirNome(nome);
            DefinirCnh(cnh);
            DefinirEndereco(endereco);
            DefinirCelular(celular);
            DefinirTelefone(telefone);

            Validar();
        }

        public string Nome { get; private set; }
        public long NumeroCarteiraNacionalDeHabilitacao { get; private set; }
        public string Telefone { get; private set; }
        public string Celular { get; private set; }
        public string Endereco { get; private set; }

        public ICollection<Veiculo> Veiculos { get; private set; }

        public void DefinirNome(string valor)
        {
            Nome = valor;
        }

        public void DefinirCnh(long valor)
        {
            NumeroCarteiraNacionalDeHabilitacao = valor;
        }

        public void DefinirTelefone(string valor)
        {
            Telefone = valor;
        }

        public void DefinirCelular(string valor)
        {
            Celular = valor;
        }

        public void DefinirEndereco(string valor)
        {
            Endereco = valor;
        }
    }
}
