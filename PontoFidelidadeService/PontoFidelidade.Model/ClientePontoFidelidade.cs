using PontoFidelidade.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PontoFidelidade.Model
{
    public class ClientePontoFidelidade : IValidatableObject
    {
        [Required(ErrorMessage = "Identificador do ponto fidelidade obrigatório!")]
        public Guid ClientePontoFidelidadeId { get; set; }

        /// <summary>
        /// Identificador do cliente que teve o saldo alterado
        /// </summary>
        [Required(ErrorMessage = "Cliente obrigatória!")]
        public Guid IdCliente { get; set; }

        /// <summary>
        /// Loja que efetuou a operação no saldo do cliente
        /// </summary>
        [Required(ErrorMessage = "Identificador da loja obrigatório!")]
        public Guid IdLoja { get; set; }

        /// <summary>
        /// Pontos inteiros da operação realizada
        /// </summary>
        [Required(ErrorMessage = "Pontos obrigatório!")]
        [Range(1, 9999999, ErrorMessage = "Pontos inválidos! Faça uma operação de 0 a 9999999 pontos ")]
        public long Pontos { get; set; }

        /// <summary>
        /// Valor atualizado da ultima movimentação com a movimentação atual
        /// </summary>
        [Required(ErrorMessage = "Saldo atual obrigatório!")]
        [Range(0, 9999999, ErrorMessage = "Saldo atual inválido!")]
        public long SaldoAtual { get; set; }

        /// <summary>
        /// Operacao realizada define se adiciona ou subtrai do saldo do cliente
        /// </summary>
        [Required(ErrorMessage = "Operação para pontos do cliente obrigatório!")]
        public Operacao Operacao { get; set; }

        /// <summary>
        /// Data hora da operação
        /// </summary>
        [Required(ErrorMessage = "Data da operação obrigatória!")]
        [DataType(DataType.Date)]
        public DateTime DataOperacao { get; set; }

        public Cliente Cliente { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataOperacao > DateTime.Today)
            {
                yield return new ValidationResult(
                    $"Data da Operação dos pontos não pode ser maior que hoje!",
                    new[] { "DataOperacao" });
            }
        }
    }
}
