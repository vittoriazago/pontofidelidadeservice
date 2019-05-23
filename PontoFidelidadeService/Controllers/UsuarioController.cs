using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using PontoFidelidade.Domain.Models;
using PontoFidelidade.WebApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PontoFidelidade.WebApi.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _UsuarioManager;
        private readonly IMapper _mapper;

        public UsuarioController(IConfiguration config,
            SignInManager<Usuario> signInManager,
            UserManager<Usuario> UsuarioManager,
            IMapper mapper
            )
        {
            _config = config;
            _signInManager = signInManager;
            _UsuarioManager = UsuarioManager;
            _mapper = mapper;
        }

        [HttpPost("")]
        [AllowAnonymous]
        public async Task<ActionResult<UsuarioNovoDto>> PostUsuario(UsuarioNovoDto usuarioNovoDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioNovoDto);
                usuario.Ativo = true;
                usuario.DataCadastro = DateTime.Now;
                var result = await _UsuarioManager.CreateAsync(usuario, usuarioNovoDto.Password);

                var usuarioDto = _mapper.Map<UsuarioNovoDto>(usuario);
                if (!result.Succeeded)
                    return BadRequest(result.Errors);

                return Created($"~/", usuarioDto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro na inserção!");
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UsuarioLoginDto usuarioLoginDto)
        {
            try
            {
                var usuario = await _UsuarioManager.FindByNameAsync(usuarioLoginDto.UserName);

                var result = await _signInManager.CheckPasswordSignInAsync(usuario, usuarioLoginDto.Password, false);

                if (!result.Succeeded)
                    return Unauthorized();

                var appUsuario = await _UsuarioManager.Users
                        .FirstOrDefaultAsync(u => u.NormalizedUserName == usuarioLoginDto.UserName.ToUpper());

                var usuarioToReturn = _mapper.Map<UsuarioNovoDto>(usuario);

                return Ok(new
                {
                    Token = GenerateJwtToken(appUsuario).Result,
                    Usuario = usuarioToReturn
                });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro na autenticação!");
            }
        }

        private async Task<string> GenerateJwtToken(Usuario Usuario)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, Usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, Usuario.UserName),
            };
            var roles = await _UsuarioManager.GetRolesAsync(Usuario);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(5),
                SigningCredentials = creds
            };

            IdentityModelEventSource.ShowPII = true;

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
