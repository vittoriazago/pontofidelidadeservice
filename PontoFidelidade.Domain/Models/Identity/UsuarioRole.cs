using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PontoFidelidade.Domain.Models
{
    public class UsuarioRole : IdentityUserRole<int>
    {
        public Usuario Usuario { get; set; }
        public Role Role { get; set; }
        
    }
}
