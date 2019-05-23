using System;

namespace PontoFidelidade.WebApi.Models
{
    public class ClienteCadastroDto
    {
        public string CPF { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

    }
}