using PontoFidelidade.Domain.Exceptions;
using PontoFidelidade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoFidelidade.Domain.Services
{
    public class ClienteMovimentacaoService
    {
        readonly IRepositorio<Cliente> _repoCliente;
        readonly IRepositorio<Loja> _repoLoja;
        readonly IRepositorio<ClienteMovimentacao> _repoClienteMovimentacaoe;

        public ClienteMovimentacaoService(
            IRepositorio<Cliente> repoCliente,
            IRepositorio<Loja> repoLoja,
            IRepositorio<ClienteMovimentacao> repoClienteMovimentacaoe)
        {
            _repoLoja = repoLoja;
            _repoCliente = repoCliente;
            _repoClienteMovimentacaoe = repoClienteMovimentacaoe;
        }

        public ClienteMovimentacao AdicionarClienteMovimentacao(ClienteMovimentacao movimentacaoNova)
        {
            var clienteExistente =  _repoCliente.GetAsync(c => 
                        c.ClienteId == movimentacaoNova.ClienteId).Result.FirstOrDefault();
            if (clienteExistente == null)
                throw new ClienteNaoEncontradoException("Cliente não encontrado!");

            var lojaExistente = _repoLoja.GetAsync(c =>
                       c.LojaId == movimentacaoNova.LojaId).Result.FirstOrDefault();
            if (lojaExistente == null)
                throw new LojaNaoEncontradaException("Loja não encontrada!");

            var valorFinal = clienteExistente.SaldoAtual ?? 0;
            if(movimentacaoNova.Operacao == Models.Enums.Operacao.Debito)
                valorFinal -= movimentacaoNova.Valor;
            else
                valorFinal += movimentacaoNova.Valor;

            if (valorFinal < 0)
                throw new SaldoInsuficienteException("Cliente sem saldo suficiente!");

            movimentacaoNova.SaldoAtual = valorFinal;
            movimentacaoNova.ClienteMovimentacaoId = Guid.NewGuid();
            movimentacaoNova.DataOperacao = DateTime.Now;

            var mensagensValidacao = ValidacaoHelper.ValidateModel(movimentacaoNova);

            if (mensagensValidacao.Any())
                throw new EntidadeInvalidaException(string.Join(",", mensagensValidacao));

            _repoClienteMovimentacaoe.Add(movimentacaoNova);
            _repoClienteMovimentacaoe.SaveChangesAsync();
            return movimentacaoNova;
        }

        private string FormataDocumento(string documento)
        {
            return documento.Replace("-", "").Replace(".", "");
        }
    }
}
