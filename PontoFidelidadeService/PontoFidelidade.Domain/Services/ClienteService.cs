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
            var documentoSemFormatacao = documento.Replace("-", "").Replace(".", "");
            var clientes = await _repoCliente.GetAsync(c => c.CPF == documentoSemFormatacao);
            return clientes.FirstOrDefault();
        }
        public async Task<Cliente> ConsultaClientePorId(Guid id)
        {
            var clientes = await _repoCliente.GetAsync(c => c.ClienteId == id);
            return clientes.FirstOrDefault();
        }
    }
}
