using System;
using System.Collections.Generic;
using System.Text;

namespace PontoFidelidade.Domain.Exceptions
{
    public class UsuarioInvalidoException : Exception
    {
        public UsuarioInvalidoException(string message) : base(message)
        {
        }

        public UsuarioInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
