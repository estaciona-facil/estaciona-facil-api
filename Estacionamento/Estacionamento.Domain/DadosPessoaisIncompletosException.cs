using System;

namespace Estacionamento.Domain
{
    public class DadosPessoaisIncompletosException : Exception
    {
        public DadosPessoaisIncompletosException (String errorMessage, Exception ex) : base(errorMessage, ex) { }
        public DadosPessoaisIncompletosException (String errorMessage) : base(errorMessage) { }
    }
}
