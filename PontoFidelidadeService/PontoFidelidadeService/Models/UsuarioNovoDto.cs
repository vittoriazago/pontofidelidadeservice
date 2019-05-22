using System;

namespace PontoFidelidade.WebApi.Models
{
    public class UsuarioNovoDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid IdLoja { get; set; }
    }
}