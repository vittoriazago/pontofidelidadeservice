﻿using AutoMapper;
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
    [Route("api/FidelidadeService")]
    [ApiController]
    public class FidelidadeServiceController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        private readonly IMapper _mapper;

        public FidelidadeServiceController(ClienteService clienteService,
            IMapper mapper
            )
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }


        /// <summary>
        /// Cliente não precisa estar logado para consultar seu saldo atual
        /// </summary>
        /// <param name="cpf">C</param>
        /// <returns>Cliente encontrado</returns>
        [HttpGet("")]
        [Obsolete("Metódo não se encontra no padrão REST. Favor usar api/Cliente")]
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
