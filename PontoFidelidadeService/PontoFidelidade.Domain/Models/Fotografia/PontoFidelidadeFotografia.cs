using PontoFidelidade.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PontoFidelidade.Domain.Models.Fotografia
{
    public class PontoFidelidadeFotografia : IValidatableObject
    {
        [Required(ErrorMessage = "Identificador do ponto fidelidade obrigatório!")]
        public Guid ClientePontoFidelidadeFotografiaId { get; set; }
        /// <summary>
        /// Identificador do cliente que representa o lote
        /// </summary>
        [Required(ErrorMessage = "Cliente obrigatório!")]
        public Guid IdCliente { get; set; }

        /// <summary>
        /// Saldo do cliente no dia inicial da fotografia
        /// </summary>
        [Required(ErrorMessage = "Saldo inicial obrigatório!")]
        [Range(0, 9999999, ErrorMessage = "Saldo inicial inválido!")]
        public long SaldoInicial { get; set; }

        /// <summary>
        /// Saldo do cliente no dia final da fotografia
        /// </summary>
        [Required(ErrorMessage = "Saldo final obrigatório!")]
        [Range(0, 9999999, ErrorMessage = "Saldo final inválido!")]
        public long SaldoFinal { get; set; }

        /// <summary>
        /// Data do inicio do lote de movimentações
        /// </summary>
        [Required(ErrorMessage = "Data inicial da fotografia obrigatória!")]
        [DataType(DataType.Date)]
        public DateTime DataInicialFotografia { get; set; }

        /// <summary>
        /// Data do fim do lote de movimentações
        /// </summary>
        [Required(ErrorMessage = "Data final da fotografia obrigatória!")]
        [DataType(DataType.Date)]
        public DateTime DataFinalFotografia { get; set; }

        /// <summary>
        /// Quantidade de operações realizadas nesse período
        /// </summary>
        [Required(ErrorMessage = "Saldo atual obrigatório!")]
        [Range(0, 9999999, ErrorMessage = "Saldo atual inválido!")]
        public int QuantidadeOperacoes { get; set; }

        public List<ClientePontoFidelidadeFotografia> Movimentacoes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataInicialFotografia > DateTime.Today)
            {
                yield return new ValidationResult(
                    $"Data inicial da fotografia deve ser menor que hoje!",
                    new[] { "DataInicialFotografia" });
            }
            if (DataFinalFotografia > DataFinalFotografia)
            {
                yield return new ValidationResult(
                    $"Data final da fotografia deve ser menor ou igual que a inicial!",
                    new[] { "DataFinalFotografia" });
            }
        }
    }
}
