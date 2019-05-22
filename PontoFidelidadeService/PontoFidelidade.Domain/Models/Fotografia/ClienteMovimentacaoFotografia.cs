using PontoFidelidade.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PontoFidelidade.Domain.Models.Fotografia
{
    public class ClienteMovimentacaoFotografia 
    {
        [Required(ErrorMessage = "Identificador do vinculo obrigatório!")]
        public Guid ClienteMovimentacaoFotografiaId { get; set; }

        /// <summary>
        /// Identificador da fotografia
        /// </summary>
        [Required(ErrorMessage = "Fotografia obrigatória!")]
        public Guid IdMovimentacaoFotografia { get; set; }

        public MovimentacaoFotografia Fotografia { get; set; }
    }
}
