using Estacionamento.Domain.DomainObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Estacionamento.Domain.Entidades
{
    public class Proprietario : Entity, IAggregateRoot
    {
        [JsonConstructor]
        public Proprietario(string nome, long numeroCarteiraNacionalDeHabilitacao, string telefone, string celular, string endereco)
        {
            Nome = nome;
            NumeroCarteiraNacionalDeHabilitacao = numeroCarteiraNacionalDeHabilitacao;
            Telefone = telefone;
            Celular = celular;
            Endereco = endereco;
        }

        public Proprietario(string nome, string endereco, string celular, string telefone, long cnh) : base()
        {
            DefinirNome(nome);
            DefinirCnh(cnh);
            DefinirEndereco(endereco);
            DefinirCelular(celular);
            DefinirTelefone(telefone);

            Validar();
        }

        public Proprietario() { }

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
