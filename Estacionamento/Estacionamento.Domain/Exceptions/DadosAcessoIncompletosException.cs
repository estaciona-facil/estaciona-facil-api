using System;

namespace Estacionamento.Domain.Exceptions
{
    public class DadosAcessoIncompletosException : Exception
    {
        public DadosAcessoIncompletosException(string errorMessage, Exception ex) : base(errorMessage, ex) { }
        public DadosAcessoIncompletosException(string errorMessage) : base(errorMessage) { }
    }
}
