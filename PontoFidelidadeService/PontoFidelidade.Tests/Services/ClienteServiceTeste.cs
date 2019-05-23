using NUnit.Framework;
using PontoFidelidade.Domain.Models;
using PontoFidelidade.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PontoFidelidade.Tests.Services
{
    public class ClienteServiceTeste
    {
        RepositorioHelper<Cliente> _repoCliente;
        ClienteService _serviceCliente;

        string cpfTeste = "43553936827";
        string cpfTesteFormatado = "435.539.368-27";
        Guid idTeste = Guid.NewGuid();

        [SetUp]
        public void Setup()
        {
            _repoCliente = new RepositorioHelper<Cliente>();
            _repoCliente.Add(new Cliente()
            {
                CPF = cpfTeste,
                Nome = "Vittoria Zago",
                DataCadastro = DateTime.Now,
                ClienteId = idTeste
            });
            _serviceCliente = new ClienteService(_repoCliente);
        }
        [Test]
        public void Cliente_Consulta_Cpf_Sucesso()
        {
            var clienteEncontrado = _serviceCliente.ConsultaClientePorCpfCnpj(cpfTeste).Result;
            Assert.IsNotNull(clienteEncontrado);
            clienteEncontrado = _serviceCliente.ConsultaClientePorCpfCnpj(cpfTesteFormatado).Result;
            Assert.IsNotNull(clienteEncontrado);
        }
        [Test]
        public void Cliente_Consulta_Id_Sucesso()
        {
            var clienteEncontrado = _serviceCliente.ConsultaClientePorId(idTeste).Result;
            Assert.IsNotNull(clienteEncontrado);
        }
        [Test]
        public void Cliente_Consulta_Cpf_NaoEncontrado()
        {
            var clienteEncontrado = _serviceCliente.ConsultaClientePorCpfCnpj("902390324208").Result;
            Assert.IsNull(clienteEncontrado);
        }
        [Test]
        public void Cliente_Consulta_Id_NaoEncontrado()
        {
            var clienteEncontrado = _serviceCliente.ConsultaClientePorId(Guid.NewGuid()).Result;
            Assert.IsNull(clienteEncontrado);
        }
    }
}
