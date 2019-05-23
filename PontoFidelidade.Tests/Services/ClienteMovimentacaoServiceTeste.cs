using NUnit.Framework;
using PontoFidelidade.Domain.Exceptions;
using PontoFidelidade.Domain.Models;
using PontoFidelidade.Domain.Services;
using System;

namespace PontoFidelidade.Tests.Services
{
    public class ClienteMovimentacaoServiceTeste
    {
        RepositorioHelper<Loja> _repoLoja;
        RepositorioHelper<Cliente> _repoCliente;
        RepositorioHelper<ClienteMovimentacao> _repoClienteMovimentacao;
        ClienteMovimentacaoService _serviceClienteMovimentacao;

        string cpfTeste = "43553936827";
        readonly string cpfTesteFormatado = "435.539.368-27";
        Guid idClienteTeste = Guid.NewGuid();
        Guid idLojaTeste = Guid.NewGuid();

        [SetUp]
        public void Setup()
        {
            _repoLoja = new RepositorioHelper<Loja>();
            _repoLoja.Add(new Loja()
            {
                LojaId = idLojaTeste,
                Ativo = true,
                DataAbertura = DateTime.Now,
                Descricao = "Loja teste",
                CNPJ = "09123712837",
            });
            _repoCliente = new RepositorioHelper<Cliente>();
            _repoCliente.Add(new Cliente()
            {
                CPF = cpfTeste,
                Nome = "Vittoria Zago",
                DataCadastro = DateTime.Now,
                ClienteId = idClienteTeste,
                MovimentacoesDinheiro = new System.Collections.Generic.List<ClienteMovimentacao>()
                {
                    new ClienteMovimentacao()
                    {
                        SaldoAtual = 300M,
                        DataOperacao = DateTime.Now,                        
                    }
                }
            });
            _repoClienteMovimentacao = new RepositorioHelper<ClienteMovimentacao>();
            _serviceClienteMovimentacao = new ClienteMovimentacaoService(_repoCliente, _repoLoja, _repoClienteMovimentacao);
        }
        [Test]
        public void ClienteMovimentacao_Adicionar_Sucesso()
        {
            var movimentacao = _serviceClienteMovimentacao.AdicionarClienteMovimentacao(new ClienteMovimentacao()
            {
                LojaId = idLojaTeste,
                ClienteId = idClienteTeste,
                Operacao = Domain.Models.Enums.Operacao.Credito,
                Valor = 100M
            });
            Assert.IsNotNull(movimentacao);
            movimentacao = _serviceClienteMovimentacao.AdicionarClienteMovimentacao(new ClienteMovimentacao()
            {
                LojaId = idLojaTeste,
                ClienteId = idClienteTeste,
                Operacao = Domain.Models.Enums.Operacao.Debito,
                Valor = 100M
            });
            Assert.IsNotNull(movimentacao);
        }
        [Test]
        public void ClienteMovimentacao_Adicionar_Falha()
        {
            Assert.Throws<ClienteNaoEncontradoException>(() =>
            {
                var cliente = _serviceClienteMovimentacao.AdicionarClienteMovimentacao(new ClienteMovimentacao()
                {
                    LojaId = idLojaTeste,
                    ClienteId = Guid.NewGuid(),
                    Operacao = Domain.Models.Enums.Operacao.Credito,
                    Valor = 100M
                });
            });
            Assert.Throws<LojaNaoEncontradaException>(() =>
            {
                var cliente = _serviceClienteMovimentacao.AdicionarClienteMovimentacao(new ClienteMovimentacao()
                {
                    LojaId = Guid.NewGuid(),
                    ClienteId = idClienteTeste,
                    Operacao = Domain.Models.Enums.Operacao.Credito,
                    Valor = 100M
                });
            });
            Assert.Throws<SaldoInsuficienteException>(() =>
            {
                var cliente = _serviceClienteMovimentacao.AdicionarClienteMovimentacao(new ClienteMovimentacao()
                {
                    LojaId = idLojaTeste,
                    ClienteId = idClienteTeste,
                    Operacao = Domain.Models.Enums.Operacao.Debito,
                    Valor = 700M
                });
            });

            Assert.Throws<EntidadeInvalidaException>(() =>
            {
                var cliente = _serviceClienteMovimentacao.AdicionarClienteMovimentacao(new ClienteMovimentacao()
                {
                    LojaId = idLojaTeste,
                    ClienteId = idClienteTeste,
                    Operacao = Domain.Models.Enums.Operacao.Credito,
                    Valor = -80M
                });
            });
        }
    }
}
