﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PontoFidelidade.Domain.Models
{
    public class Role : IdentityRole<int>
    {

        public List<UsuarioRole> UsuarioRoles { get; set; }
        
    }
}
