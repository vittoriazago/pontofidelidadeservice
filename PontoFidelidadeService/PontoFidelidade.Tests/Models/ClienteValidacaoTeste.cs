using NUnit.Framework;
using PontoFidelidade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PontoFidelidade.Tests.Models
{
    public class ClienteValidacaoTeste : TesteBaseValidacao
    {

        [Test]
        public void Cliente_Validacao_Sucesso()
        {
            var novoCliente = new Cliente()
            {
                
            };

            Assert.AreEqual(0, ValidateModel(novoCliente).Count);
        }
    }
}
