using System;

namespace Estacionamento.Domain
{
    public class DadosVeiculosIncompletosException : Exception
    {
        public DadosVeiculosIncompletosException (String errorMessage, Exception ex) : base(errorMessage, ex) { }
        public DadosVeiculosIncompletosException (String errorMessage) : base(errorMessage) { }
    }
}
