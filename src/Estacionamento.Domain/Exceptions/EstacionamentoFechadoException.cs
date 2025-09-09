using System;

namespace Estacionamento.Domain.Exceptions
{
    public class EstacionamentoFechadoException : Exception
    {
        public EstacionamentoFechadoException (string errorMessage, Exception ex) : base(errorMessage, ex) { }
        public EstacionamentoFechadoException (string errorMessage) : base(errorMessage) { }
    }
}
