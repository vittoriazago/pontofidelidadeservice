using System;

namespace PontoFidelidade.WebApi.Models
{
    public class LojaConsultaDto
    {
        public Guid LojaId { get; set; }
        
        public string Codigo { get; set; }
        
        public Guid ChaveIntegracao { get; set; }
        
        public string Descricao { get; set; }
        
        public string CNPJ { get; set; }
        
        public DateTime DataCadastro { get; set; }
        
        public bool Ativo { get; set; }
        
        public DateTime DataAbertura { get; set; }

    }
}