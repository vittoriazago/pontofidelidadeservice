using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PontoFidelidade.Model
{
    public class Usuario : IdentityUser<int>, IValidatableObject
    {
        [Required(ErrorMessage = "Data de cadastro do usuário é obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
        
        public List<UsuarioRole> UsuarioRole { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataCadastro > DateTime.Today)
            {
                yield return new ValidationResult(
                    $"Data de cadastro de uma pessoa deve ser maior que hoje!",
                    new[] { "DataCadastro" });
            }
        }
    }
}
