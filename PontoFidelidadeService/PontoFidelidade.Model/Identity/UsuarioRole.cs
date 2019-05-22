using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PontoFidelidade.Model
{
    public class UsuarioRole : IdentityUserRole<int>
    {
        public Usuario Usuario { get; set; }
        public Role Role { get; set; }
        
    }
}
