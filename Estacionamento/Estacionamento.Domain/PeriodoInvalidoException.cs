using System;

namespace Estacionamento.Domain
{
    public class PeriodoInvalidoException : Exception
    {
        public PeriodoInvalidoException (String errorMessage, Exception ex) : base(errorMessage, ex) { }
        public PeriodoInvalidoException (String errorMessage) : base(errorMessage) { }
    }
}
