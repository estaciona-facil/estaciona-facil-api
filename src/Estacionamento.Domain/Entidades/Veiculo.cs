using Estacionamento.Domain.DomainObjects;
using Estacionamento.Domain.DomainObjects.Validations;
using System;

namespace Estacionamento.Domain.Entidades
{
    public class Veiculo : Entity, IAggregateRoot
    {
        public Veiculo() { }

        public Veiculo(string marca, string modelo, string placa) : base()
        {
            DefinirPlaca(placa);
            DefinirMarca(marca);
            DefinirModelo(modelo);

            Validar();
        }

        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Placa { get; private set; }
        public Guid ProprietarioId { get; private set; }

        public Proprietario Proprietario { get; private set; }


        public void DefinirMarca(string marca)
        {
            Marca = marca;
        }

        public void DefinirModelo(string modelo)
        {
            Modelo = modelo;
        }

        public void DefinirPlaca(string placa)
        {
            Placa = placa;
        }

        public void DefinirProprietario(Proprietario proprietario)
        {
            Proprietario = proprietario;
            ProprietarioId = proprietario.Id;
        }

        public override void Validar()
        {
            BaseValidations.ValidarExpressao(@"^[A-Z]{3}-\d{4}$|^[A-Z]{3}-[0-9][A-Z][0-9]{2}$", Placa, "");
            BaseValidations.ValidarSeVazio(Modelo, "");
            BaseValidations.ValidarSeVazio(Marca, "");
            base.Validar();
        }
    }
}
