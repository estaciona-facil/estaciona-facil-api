using System;

namespace Estacionamento.Domain.Exceptions
{
    public class DadosVeiculosIncompletosException : Exception
    {
        public DadosVeiculosIncompletosException (string errorMessage, Exception ex) : base(errorMessage, ex) { }
        public DadosVeiculosIncompletosException (string errorMessage) : base(errorMessage) { }
    }
}
