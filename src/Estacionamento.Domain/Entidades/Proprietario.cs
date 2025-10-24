using Estacionamento.Domain.DomainObjects;
using Estacionamento.Domain.DomainObjects.Validations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Estacionamento.Domain.Entidades
{
    public class Proprietario : Entity, IAggregateRoot
    {
        [JsonConstructor]
        public Proprietario(Guid id, string nome, long numeroCarteiraNacionalDeHabilitacao, string telefone, string celular, string endereco) : base(id)
        {
            Nome = nome;
            NumeroCarteiraNacionalDeHabilitacao = numeroCarteiraNacionalDeHabilitacao;
            Telefone = telefone;
            Celular = celular;
            Endereco = endereco;
        }

        public Proprietario(string nome, long numeroCarteiraNacionalDeHabilitacao, string telefone, string celular, string endereco) : base()
        {
            DefinirNome(nome);
            DefinirCnh(numeroCarteiraNacionalDeHabilitacao);
            DefinirEndereco(endereco);
            DefinirCelular(celular);
            DefinirTelefone(telefone);
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
            BaseValidations.ValidarSeVazio(valor.ToString(), MensagemDeCampoNaoInformadoOuInvalido(nameof(Nome)));
            BaseValidations.ValidarCaracteres(valor, 0, 150, nameof(Nome));
            Nome = valor;
        }

        public void DefinirCnh(long valor)
        {
            BaseValidations.ValidarSeVazio(valor.ToString(), MensagemDeCampoNaoInformadoOuInvalido(nameof(NumeroCarteiraNacionalDeHabilitacao)));
            BaseValidations.ValidarCaracteres(valor.ToString(), 9, 9, nameof(NumeroCarteiraNacionalDeHabilitacao));
            NumeroCarteiraNacionalDeHabilitacao = valor;
        }

        public void DefinirTelefone(string valor)
        {
            BaseValidations.ValidarSeVazio(valor, MensagemDeCampoNaoInformadoOuInvalido(nameof(Telefone)));
            BaseValidations.ValidarCaracteres(valor.ToString(), 9, 9, nameof(Telefone));
            BaseValidations.ValidarExpressao("^55\\d{10,11}$\r\n", valor ,nameof(Telefone));
            Telefone = valor;
        }

        public void DefinirCelular(string valor)
        {
            BaseValidations.ValidarSeVazio(valor, MensagemDeCampoNaoInformadoOuInvalido(nameof(Celular)));
            BaseValidations.ValidarCaracteres(valor.ToString(), 12, 13, nameof(Celular));
            BaseValidations.ValidarExpressao("^55\\d{10,11}$\r\n", valor, nameof(Celular));
            Celular = valor;
        }

        public void DefinirEndereco(string valor)
        {
            BaseValidations.ValidarSeVazio(valor, MensagemDeCampoNaoInformadoOuInvalido(nameof(Endereco)));
            BaseValidations.ValidarCaracteres(valor, 0, 150, MensagemDeCampoNaoInformadoOuInvalido(nameof(Endereco)));
            Endereco = valor;
        }
    }
}
