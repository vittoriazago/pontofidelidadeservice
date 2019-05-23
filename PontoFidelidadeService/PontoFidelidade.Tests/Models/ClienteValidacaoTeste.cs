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
                CPF = "43553936827",
                Nome = "Vittoria Zago",
                DataCadastro = DateTime.Now,
                ClienteId = Guid.NewGuid()
            };

            Assert.AreEqual(0, ValidateModel(novoCliente).Count);
        }
        [Test]
        public void Cliente_Validacao_Falha()
        {
            var novoCliente = new Cliente()
            {
                Nome = "Vittoria Zago",
                DataCadastro = DateTime.Now,
                ClienteId = Guid.NewGuid()
            };
            Assert.AreEqual(1, ValidateModel(novoCliente).Count);
            novoCliente = new Cliente()
            {
                CPF = "43553936827",
                DataCadastro = DateTime.Now,
                ClienteId = Guid.NewGuid()
            };
            Assert.AreEqual(1, ValidateModel(novoCliente).Count);
            novoCliente = new Cliente()
            {
                CPF = "43553936827980802388374390",
                DataCadastro = DateTime.Now,
                Nome = "Vittoria Zago",
                ClienteId = Guid.NewGuid()
            };
            Assert.AreEqual(1, ValidateModel(novoCliente).Count);
            novoCliente = new Cliente()
            {
                CPF = "43553936827",
                Nome = "Vittoria Zago",
                ClienteId = Guid.NewGuid()
            };
            Assert.AreEqual(1, ValidateModel(novoCliente).Count);
            novoCliente = new Cliente()
            {
                CPF = "43553936827",
                Nome = "Vittoria Zago",
                DataCadastro = DateTime.Today.AddDays(5),
                ClienteId = Guid.NewGuid()
            };
            Assert.AreEqual(1, ValidateModel(novoCliente).Count);
            novoCliente = new Cliente()
            {
                CPF = "43553936827",
                Nome = "Vittoria Zago",
                DataCadastro = DateTime.Now,
            };
            Assert.AreEqual(1, ValidateModel(novoCliente).Count);

        }
    }
}
