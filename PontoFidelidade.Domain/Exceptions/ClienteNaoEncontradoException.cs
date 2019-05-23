using System;
using System.Collections.Generic;
using System.Text;

namespace PontoFidelidade.Domain.Exceptions
{
    public class ClienteNaoEncontradoException : Exception
    {
        public ClienteNaoEncontradoException(string message) : base(message)
        {
        }

        public ClienteNaoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
