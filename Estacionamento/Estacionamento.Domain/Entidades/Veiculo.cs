using System;

namespace Estacionamento.Domain.Entidades
{
    public class Veiculo
    {
        public Veiculo(string marca, string modelo, string placa)
        {
            DefinirPlaca(placa);
            DefinirMarca(marca);
            DefinirModelo(modelo);
        }

        public Guid Id { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Placa { get; private set; }

        public virtual Proprietario Proprietario { get; set; }


        public void DefinirMarca(string marca)
        {
            this.Marca = marca;
        }

        public void DefinirModelo(string modelo)
        {
            this.Modelo = modelo;
        }

        public void DefinirPlaca(string placa)
        {
            this.Placa = placa;
        }

        public void DefinirProprietario(Proprietario proprietario)
        {
            this.Proprietario = proprietario;
        }
    }
}
