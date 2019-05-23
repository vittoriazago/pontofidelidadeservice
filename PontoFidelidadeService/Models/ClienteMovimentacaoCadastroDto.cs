using System;

namespace PontoFidelidade.WebApi.Models
{
    public class ClienteMovimentacaoCadastroDto
    {
        public Guid ClienteId { get; set; }
        public Guid LojaId { get; set; }

        public decimal ValorOperacao { get; set; }

        public Domain.Models.Enums.Operacao Operacao { get; set; }

    }
}