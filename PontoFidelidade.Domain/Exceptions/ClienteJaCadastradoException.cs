using System;
using System.Collections.Generic;
using System.Text;

namespace PontoFidelidade.Domain.Exceptions
{
    public class ClienteJaCadastradoException : Exception
    {
        public ClienteJaCadastradoException(string message) : base(message)
        {
        }

        public ClienteJaCadastradoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
