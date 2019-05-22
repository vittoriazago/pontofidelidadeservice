using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PontoFidelidade.Model
{
    public class Cliente : IValidatableObject
    {
        [Required(ErrorMessage = "Identificador do cliente obrigatório!")]
        public Guid ClienteId { get; set; }

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


        public decimal? SaldoAtual
        {
            get
            {
                return MovimentacoesDinheiro.OrderByDescending(d => d.DataOperacao).FirstOrDefault()?.SaldoAtual;
            }
        }
        public long? PontosAtual
        {
            get
            {
                return MovimentacoesPontoFidelidade.OrderByDescending(d => d.DataOperacao).FirstOrDefault()?.SaldoAtual;
            }
        }
        public List<ClienteMovimentacao> MovimentacoesDinheiro { get; set; }
        public List<ClientePontoFidelidade> MovimentacoesPontoFidelidade { get; set; }

        public List<Fotografia.MovimentacaoFotografia> ExtratosMovimentacao { get; set; }
        public List<Fotografia.PontoFidelidadeFotografia> ExtratosPontoFidelidade { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataCadastro > DateTime.Today)
            {
                yield return new ValidationResult(
                    $"Data de cadastro de uma pessoa não pode ser maior que hoje!",
                    new[] { "DataCadastro" });
            }
        }
    }
}
