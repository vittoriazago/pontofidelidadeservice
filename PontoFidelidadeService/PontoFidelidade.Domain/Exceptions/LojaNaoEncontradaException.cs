using System;
using System.Collections.Generic;
using System.Text;

namespace PontoFidelidade.Domain.Exceptions
{
    public class LojaNaoEncontradaException : Exception
    {
        public LojaNaoEncontradaException(string message) : base(message)
        {
        }

        public LojaNaoEncontradaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
