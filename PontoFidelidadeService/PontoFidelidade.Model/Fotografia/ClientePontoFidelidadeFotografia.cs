using PontoFidelidade.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PontoFidelidade.Model.Fotografia
{
    public class ClientePontoFidelidadeFotografia 
    {
        [Required(ErrorMessage = "Identificador do vínculo obrigatório!")]
        public Guid ClientePontoFidelidadeFotografiaId { get; set; }

        /// <summary>
        /// Identificador da fotografia
        /// </summary>
        [Required(ErrorMessage = "Fotografia obrigatória!")]
        public Guid IdPontoFidelidadeFotografia { get; set; }

        public PontoFidelidadeFotografia Fotografia { get; set; }
    }
}
