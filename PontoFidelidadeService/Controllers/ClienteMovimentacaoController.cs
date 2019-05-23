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
    [Route("api/cliente/movimentacao")]
    [ApiController]
    public class ClienteMovimentacaoController : ControllerBase
    {
        private readonly ClienteMovimentacaoService _clienteService;
        private readonly IMapper _mapper;

        public ClienteMovimentacaoController(ClienteMovimentacaoService clienteService,
            IMapper mapper
            )
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        /// <summary>
        /// Cadastrar um nova movimentação para um cliente
        /// </summary>
        /// <param name="movimentacaoDto">Dados de da movimentação</param>
        /// <returns>Movimentação cadastrada</returns>
        [HttpPost("")]
        public async Task<ActionResult<ClienteConsultaDto>> Post(ClienteMovimentacaoCadastroDto movimentacaoDto)
        {
            var movimentacao = _mapper.Map<ClienteMovimentacao>(movimentacaoDto);
            movimentacao = _clienteService.AdicionarClienteMovimentacao(movimentacao);

            var clienteRetrono = _mapper.Map<ClienteConsultaDto>(movimentacao);

            return Ok(clienteRetrono);
        }

    }
}
