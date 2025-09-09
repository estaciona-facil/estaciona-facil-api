﻿using System;

namespace Estacionamento.Domain
{
    public class Veiculo
    {
        private String marca;
        private String modelo;
        private String placa;
        private bool p;

        private Proprietario proprietario;

        public String getMarca()
        {
            return marca;
        }
        public void setMarca(String marca)
        {
            this.marca = marca;
        }

        public String getModelo()
        {
            return modelo;
        }
        public void setModelo(String modelo)
        {
            this.modelo = modelo;
        }

        public String getPlaca()
        {
            return placa;
        }
        public void setPlaca(String placa)
        {
            this.placa = placa;
        }

        public Proprietario getProprietario()
        {
            return proprietario;
        }
        public void setProprietario(Proprietario p)
        {
            this.proprietario = p;
            this.p = true;
        }

        //This is constructor of Veiculo Class
        public Veiculo(String marca, String modelo, String placa)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.placa = placa;
            proprietario = null;
            this.p = false;
        }
    }
}
