using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PontoFidelidade.Domain.Models;
using PontoFidelidade.Domain.Services;
using PontoFidelidade.WebApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PontoFidelidade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(ClienteService clienteService,
            IMapper mapper
            )
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        /// <summary>
        /// Consultar cliente por id
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <returns>Cliente encontrado</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteConsultaDto>> Get(Guid id)
        {
            var cliente = await _clienteService.ConsultaClientePorId(id);

            if (cliente == null)
                return NotFound("Cliente não encontrado!");

            var clienteDto = _mapper.Map<ClienteConsultaDto>(cliente);

            return Ok(clienteDto);
        }

        /// <summary>
        /// Consultar cliente por cpf
        /// </summary>
        /// <remarks>
        /// Cliente não precisa estar logado para consultar seu saldo atual
        /// </remarks>
        /// <param name="cpf">Cpf do cliente</param>
        /// <returns>Cliente encontrado</returns>
        [HttpGet("")]
        [AllowAnonymous]
        public async Task<ActionResult<ClienteConsultaDto>> GetPessoaCpfCnpj(string cpf)
        {
            var cliente = await _clienteService.ConsultaClientePorCpfCnpj(cpf);

            if (cliente == null)
                return NotFound("Cliente não encontrado!");

            var clienteDto = _mapper.Map<ClienteConsultaDto>(cliente);

            return Ok(clienteDto);
        }

        /// <summary>
        /// Cadastrar um novo cliente
        /// </summary>
        /// <param name="clienteDto">Dados de um cliente</param>
        /// <returns>Cliente cadastrado</returns>
        [HttpPost("")]
        public async Task<ActionResult<ClienteConsultaDto>> Post(ClienteCadastroDto clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            cliente = _clienteService.AdicionarCliente(cliente);

            var clienteRetrono = _mapper.Map<ClienteConsultaDto>(cliente);

            return Ok(clienteRetrono);
        }

    }
}
