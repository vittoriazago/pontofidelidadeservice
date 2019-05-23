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
        /// Cliente não precisa estar logado para consultar seu saldo atual
        /// </summary>
        /// <param name="cpf">C</param>
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
        
    }
}
