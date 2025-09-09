using System;

namespace Estacionamento.Domain
{
    public class DadosAcessoIncompletosException : Exception
    {
        public DadosAcessoIncompletosException(String errorMessage, Exception ex) : base(errorMessage, ex) { }
        public DadosAcessoIncompletosException(String errorMessage) : base(errorMessage) { }
    }
}
