using Estacionamento.Domain.DomainObjects;
using Estacionamento.Domain.DomainObjects.Validations;
using Newtonsoft.Json;
using System;

namespace Estacionamento.Domain.Entidades
{
    public class Veiculo : Entity, IAggregateRoot
    {
        [JsonConstructor]
        public Veiculo(Guid id, string marca, string modelo, string placa, Guid proprietarioId) : base(id)
        {
            Marca = marca;
            Modelo = modelo;
            Placa = placa;
            ProprietarioId = proprietarioId;
        }

        public Veiculo(string marca, string modelo, string placa, Guid proprietarioId) : base()
        {
            DefinirPlaca(placa);
            DefinirMarca(marca);
            DefinirModelo(modelo);
            DefinirProprietarioPorId(proprietarioId);
        }

        public Veiculo(Guid id) 
        {
            DefinirId(id);
        }

        public Veiculo() { }

        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Placa { get; private set; }
        public Guid ProprietarioId { get; private set; }

        public Proprietario Proprietario { get; private set; }


        public void DefinirMarca(string valor)
        {
            BaseValidations.ValidarSeVazio(valor, MensagemDeCampoNaoInformadoOuInvalido(nameof(Marca)));
            BaseValidations.ValidarCaracteres(valor, 0, 50, nameof(Marca));
            Marca = valor;
        }

        public void DefinirModelo(string valor)
        {
            BaseValidations.ValidarSeVazio(valor, MensagemDeCampoNaoInformadoOuInvalido(nameof(Modelo)));
            BaseValidations.ValidarCaracteres(valor, 0, 100, nameof(Modelo));
            Modelo = valor;
        }

        public void DefinirPlaca(string valor)
        {
            BaseValidations.ValidarSeVazio(valor, MensagemDeCampoNaoInformadoOuInvalido(nameof(Placa)));
            BaseValidations.ValidarExpressao("[A-Z]{3}[0-9][0-9A-Z][0-9]{2}", valor, MensagemDeCampoNaoInformadoOuInvalido(nameof(Placa)));
            Placa = valor;
        }

        public void DefinirProprietario(Proprietario proprietario)
        {
            Proprietario = proprietario;
            ProprietarioId = proprietario.Id;
        }

        public void DefinirProprietarioPorId(Guid proprietarioId)
        {

            BaseValidations.ValidarEhDiferente(proprietarioId, Guid.Empty, MensagemDeCampoNaoInformadoOuInvalido(nameof(proprietarioId)));
            ProprietarioId = proprietarioId;
        }
    }
}
