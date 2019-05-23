using System;
using System.Collections.Generic;
using System.Text;

namespace PontoFidelidade.Domain.Exceptions
{
    public class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException(string message) : base(message)
        {
        }

        public SaldoInsuficienteException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
