using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PontoFidelidade.Domain.Models
{
    public class Usuario : IdentityUser<int>, IValidatableObject
    {
        /// <summary>
        /// Loja responsável pelo usuário
        /// </summary>
        [Required(ErrorMessage = "Identificador da loja obrigatório!")]
        public Guid LojaId { get; set; }

        /// <summary>
        /// Data em que a loja cadastrou o usuário
        /// </summary>
        [Required(ErrorMessage = "Data de cadastro do usuário é obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Usuário ativo ou não
        /// </summary>
        [Required(ErrorMessage = "Data de cadastro do usuário é obrigatório!")]
        public bool Ativo { get; set; }

        public List<UsuarioRole> UsuarioRoles { get; set; }

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
