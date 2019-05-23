using PontoFidelidade.Domain.Exceptions;
using PontoFidelidade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoFidelidade.Domain.Services
{
    public class LojaService
    {
        readonly IRepositorio<Loja> _repoLoja;
        readonly IRepositorio<Usuario> _repoUsuario;

        public LojaService(
            IRepositorio<Loja> repoLoja,
            IRepositorio<Usuario> repoUsuario)
        {
            _repoLoja = repoLoja;
            _repoUsuario = repoUsuario;
        }

        public async Task<IEnumerable<Loja>> ConsultaLojas(bool ativo)
        {
            var lojas = await _repoLoja.GetAsync(c => c.Ativo == ativo);
            return lojas;
        }

        public async Task AlteraLoja(int idUsuario, Guid lojaId, AlteraLojaDto alteracao)
        {
            var usuarioAlteracao = (await _repoUsuario.GetAsync(c => c.Id == idUsuario
                                            && c.Ativo)).FirstOrDefault();
            if (usuarioAlteracao == null)
                throw new UsuarioInvalidoException("Usuário inválido!");
           
            if (usuarioAlteracao.LojaId != lojaId)
                throw new SemPermissaoAlteracaoException("Usuário sem permissão para alterar dados de outra loja!");

            var loja = (await _repoLoja.GetAsync(c => c.LojaId == lojaId
                                            && c.Ativo)).FirstOrDefault();
            if (loja == null)
                throw new LojaNaoEncontradaException("Loja inválida!");

            loja.Codigo = alteracao.Codigo;
            loja.ChaveIntegracao = alteracao.ChaveIntegracao;
            _repoLoja.Update(loja);
            _repoLoja.SaveChangesAsync();

        }

        #region dtos

        public class AlteraLojaDto
        {
            public string Codigo { get; set; }
            public Guid ChaveIntegracao { get; set; }
        }
        #endregion
    }

}
