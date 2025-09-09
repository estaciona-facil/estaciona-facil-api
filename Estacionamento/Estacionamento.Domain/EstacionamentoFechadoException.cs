using System;

namespace Estacionamento.Domain
{
    public class EstacionamentoFechadoException : Exception
    {
        public EstacionamentoFechadoException (String errorMessage, Exception ex) : base(errorMessage, ex) { }
        public EstacionamentoFechadoException (String errorMessage) : base(errorMessage) { }
    }
}
