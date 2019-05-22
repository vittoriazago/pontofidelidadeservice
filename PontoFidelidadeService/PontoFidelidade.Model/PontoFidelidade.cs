using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PontoFidelidade.Model
{
    public class PontoFidelidade : IValidatableObject
    {
        [Required(ErrorMessage = "Identificador do ponto fidelidade obrigatório!")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Descrição obrigatória!")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "Descrição deve ter no máximo 40 carácteres!")]
        public string Descrição { get; set; }

        [Required(ErrorMessage = "Status obrigatório!")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Data de cadastro do ponto fidelidade obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataCadastro > DateTime.Today)
            {
                yield return new ValidationResult(
                    $"Data de cadastro do ponto fidelidade deve ser maior que hoje!",
                    new[] { "DataCadastro" });
            }
        }
    }
}
