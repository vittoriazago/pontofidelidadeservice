using PontoFidelidade.Domain.Exceptions;
using PontoFidelidade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoFidelidade.Domain.Services
{
    public class ClienteService
    {
        readonly IRepositorio<Cliente> _repoCliente;

        public ClienteService(IRepositorio<Cliente> repoCliente)
        {
            _repoCliente = repoCliente;
        }

        public async Task<Cliente> ConsultaClientePorCpfCnpj(string documento)
        {
            var documentoSemFormatacao = FormataDocumento(documento);
            var clientes = await _repoCliente.GetAsync(c => c.CPF == documentoSemFormatacao);
            return clientes.FirstOrDefault();
        }
        public async Task<Cliente> ConsultaClientePorId(Guid id)
        {
            var clientes = await _repoCliente.GetAsync(c => c.ClienteId == id);
            return clientes.FirstOrDefault();
        }
        public Cliente AdicionarCliente(Cliente clienteNovo)
        {
            var documentoSemFormatacao = FormataDocumento(clienteNovo.CPF);

            var clienteExistente =  _repoCliente.GetAsync(c => c.CPF == documentoSemFormatacao).Result.FirstOrDefault();
            if (clienteExistente != null)
                throw new ClienteJaCadastradoException("Cliente já existente com este CPF!");

            clienteNovo.ClienteId = Guid.NewGuid();
            clienteNovo.DataCadastro = DateTime.Now;
            clienteNovo.CPF = documentoSemFormatacao;

            var mensagensValidacao = ValidacaoHelper.ValidateModel(clienteNovo);

            if (mensagensValidacao.Any())
                throw new EntidadeInvalidaException(string.Join(",", mensagensValidacao));

            _repoCliente.Add(clienteNovo);
            _repoCliente.SaveChangesAsync();
            return clienteNovo;
        }

        private string FormataDocumento(string documento)
        {
            return documento.Replace("-", "").Replace(".", "");
        }
    }
}
