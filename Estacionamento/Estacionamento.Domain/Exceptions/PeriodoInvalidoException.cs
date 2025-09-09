using System;

namespace Estacionamento.Domain.Exceptions
{
    public class PeriodoInvalidoException : Exception
    {
        public PeriodoInvalidoException (string errorMessage, Exception ex) : base(errorMessage, ex) { }
        public PeriodoInvalidoException (string errorMessage) : base(errorMessage) { }
    }
}
