using System;
using System.Collections.Generic;
using System.Text;

namespace PontoFidelidade.Domain.Exceptions
{
    public class SemPermissaoAlteracaoException : Exception
    {
        public SemPermissaoAlteracaoException(string message) : base(message)
        {
        }

        public SemPermissaoAlteracaoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
