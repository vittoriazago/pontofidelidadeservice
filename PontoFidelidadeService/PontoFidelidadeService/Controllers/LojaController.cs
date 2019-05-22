using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PontoFidelidade.Domain.Models;
using PontoFidelidade.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static PontoFidelidade.Domain.Services.LojaService;

namespace PontoFidelidade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LojaController : ControllerBase
    {
        private readonly LojaService _lojaService;
        private readonly IMapper _mapper;

        public LojaController(LojaService lojaService,
            IMapper mapper
            )
        {
            _lojaService = lojaService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Loja>>> Get(bool? ativo = true)
        {
            var lojas = await _lojaService.ConsultaLojas(ativo.Value);

            var lojasDtos = _mapper.Map<IEnumerable<Loja>>(lojas);

            return Ok(lojasDtos);
        }

        /// <summary>
        /// Atualiza informações sobre a loja
        /// </summary>
        /// <param name="id">Identificador da loja</param>
        /// <param name="idUsuario">Usuário vinculado com a loja</param>
        /// <param name="alteraLojaDto">Objeto com dados para alteração</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> PutAtualizaLoja([FromRoute]Guid id, int idUsuario, AlteraLojaDto alteraLojaDto)
        {
            await _lojaService.AlteraLoja(idUsuario, id, alteraLojaDto);
            return Ok();
        }

    }
}
