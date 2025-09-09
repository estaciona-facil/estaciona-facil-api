using System;

namespace Estacionamento.Domain.Exceptions
{
    public class DadosPessoaisIncompletosException : Exception
    {
        public DadosPessoaisIncompletosException (string errorMessage, Exception ex) : base(errorMessage, ex) { }
        public DadosPessoaisIncompletosException (string errorMessage) : base(errorMessage) { }
    }
}
