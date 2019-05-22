using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PontoFidelidade.Domain.Models;
using PontoFidelidade.Domain.Services;
using PontoFidelidade.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
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
        /// <summary>
        /// Recupera lojas de acordo com o status
        /// </summary>
        /// <param name="ativo">Filtras lojas ativas ou não</param>
        /// <returns></returns>
        [HttpGet("")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<LojaConsultaDto>>> Get(bool? ativo = true)
        {
            var lojas = await _lojaService.ConsultaLojas(ativo.Value);

            var lojasDtos = _mapper.Map<IEnumerable<LojaConsultaDto>>(lojas);

            return Ok(lojasDtos);
        }

        /// <summary>
        /// Atualiza informações sobre a loja 
        /// </summary>
        /// <remarks>
        /// Apenas usuários vinculados a loja podem alterar essas informações
        /// </remarks>
        /// <param name="id">Identificador da loja</param>
        /// <param name="alteraLojaDto">Objeto com dados para alteração</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtualizaLoja([FromRoute]Guid id, AlteraLojaDto alteraLojaDto)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            await _lojaService.AlteraLoja(int.Parse(currentUserID), id, alteraLojaDto);
            return Ok();
        }

    }
}
