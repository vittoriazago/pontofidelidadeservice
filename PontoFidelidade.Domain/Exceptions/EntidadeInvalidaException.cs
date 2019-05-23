using System;
using System.Collections.Generic;
using System.Text;

namespace PontoFidelidade.Domain.Exceptions
{
    public class EntidadeInvalidaException : Exception
    {
        public EntidadeInvalidaException(string message) : base(message)
        {
        }

        public EntidadeInvalidaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
