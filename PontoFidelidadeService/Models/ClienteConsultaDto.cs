using System;

namespace PontoFidelidade.WebApi.Models
{
    public class ClienteConsultaDto
    {
        public Guid ClienteId { get; set; }

        public string CPF { get; set; }

        public string Nome { get; set; }

        public decimal SaldoAtualDinheiro { get; set; }

        public long SaldoAtualPontos { get; set; }

    }
}