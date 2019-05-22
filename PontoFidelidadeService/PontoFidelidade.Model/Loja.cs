using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PontoFidelidade.Model
{
    public class Loja : IValidatableObject
    {
        [Required(ErrorMessage = "Identificador da loja obrigatório!")]
        public Guid Id { get; set; }
        
        [StringLength(999999, MinimumLength = 1, ErrorMessage = "Código inválido!")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Descrição obrigatório!")]
        [StringLength(200, ErrorMessage = "Descrição deve conter no máximo 200 caractéres!")]
        public string Descricao { get; set; }

        [StringLength(14, MinimumLength = 14, ErrorMessage = "CNPJ deve conter 14 dígitos!")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Data de cadastro da loja obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Status obrigatório!")]
        public bool Ativo { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataAbertura { get; set; }
        

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataCadastro > DateTime.Today)
            {
                yield return new ValidationResult(
                    $"Data de cadastro de uma loja deve ser maior que hoje!",
                    new[] { "DataCadastro" });
            }
            if (DataAbertura > DateTime.Today)
            {
                yield return new ValidationResult(
                    $"Data de abertura de uma loja deve ser maior que hoje!",
                    new[] { "DataCadastro" });
            }
        }
    }
}
