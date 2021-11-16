using senai_SpMedGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webAPI.Interfaces
{
    interface ISituacaoRepository
    {
        /// <summary>
        /// Lista todos as Situações
        /// </summary>
        /// <returns></returns>
        List<Situacao> ListarTodos();

        /// <summary>
        /// Busca uma Situacao através do id
        /// </summary>
        /// <param name="idSituacao">Id da Situacao a ser buscada</param>
        /// <returns></returns>
        Situacao BuscarPorId(int idSituacao);

        /// <summary>
        /// Cadastra uma nova Situacao
        /// </summary>
        /// <param name="novaSituacao">Objeto Situacao a ser cadastrado</param>
        void Cadastrar(Situacao novaSituacao);

        /// <summary>
        /// Deleta uma Situacao através do id
        /// </summary>
        /// <param name="idSituacao">Id da Situacao a ser deletada</param>
        void Deletar(int idSituacao);

        /// <summary>
        /// Atualiza uma Situacao através do id
        /// </summary>
        /// <param name="idSituacao">Id da Situacao a ser atualizada</param>
        /// <param name="SituacaoAtualizada">Objeto Situacao a ser atualizado</param>
        void AtualizarUrl(int idSituacao, Situacao SituacaoAtualizada);
    }
}
