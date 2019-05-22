﻿using PontoFidelidade.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PontoFidelidade.Model
{
    public class ClienteMovimentacao : IValidatableObject
    {
        [Required(ErrorMessage = "Identificador da movimentação obrigatório!")]
        public Guid ClienteMovimentacaoId { get; set; }

        /// <summary>
        /// Identificador do cliente que teve o saldo alterado
        /// </summary>
        [Required(ErrorMessage = "Cliente obrigatório!")]
        public Guid IdCliente { get; set; }

        /// <summary>
        /// Loja que efetuou a operação no saldo do cliente
        /// </summary>
        [Required(ErrorMessage = "Identificador da loja obrigatório!")]
        public Guid IdLoja { get; set; }

        /// <summary>
        /// Valor em reais da operação realizada
        /// </summary>
        [Required(ErrorMessage = "Valor obrigatório!")]
        [Range(1, 9999999, ErrorMessage = "Valor inválidos! Faça uma operação de 0 a 9999999 reais!")]
        public long Valor { get; set; }

        /// <summary>
        /// Valor atualizado da ultima movimentação com a movimentação atual
        /// </summary>
        [Required(ErrorMessage = "Saldo atual obrigatório!")]
        [Range(0, 9999999, ErrorMessage = "Saldo atual inválido!")]
        public long SaldoAtual { get; set; }

        /// <summary>
        /// Operacao realizada define se adiciona ou subtrai do saldo do cliente
        /// </summary>
        [Required(ErrorMessage = "Operação para saldo do cliente obrigatório!")]
        public Operacao Operacao { get; set; }

        /// <summary>
        /// Data hora da operação
        /// </summary>
        [Required(ErrorMessage = "Data da operação obrigatória!")]
        [DataType(DataType.Date)]
        public DateTime DataOperacao { get; set; }

        public Cliente Cliente { get; set; }
        public Loja Loja { get; set; }

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
