using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PontoFidelidade.Model
{
    public class Cliente : IValidatableObject
    {
        [Required(ErrorMessage = "Identificador da pessoa obrigatório!")]
        public Guid Id { get; set; }
        
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve conter 11 dígitos!")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Nome obrigatório!")]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Nome deve conter no máximo 200 caractéres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data de cadastro da pessoa obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

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
