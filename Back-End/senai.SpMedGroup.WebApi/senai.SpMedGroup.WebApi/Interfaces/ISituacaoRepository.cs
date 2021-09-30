using senai.SpMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Interfaces
{
    interface ISituacaoRepository
    {
        /// <summary>
        /// Lista todos as situações
        /// </summary>
        /// <returns>Uma lista de situações</returns>
        List<Situacao> ListarTodas();

        /// <summary>
        /// Busca uma situação através do ID
        /// </summary>
        /// <param name="idSituacao">ID da situação que será buscada</param>
        /// <returns>Uma situação buscada</returns>
        Situacao BuscarPorId(int idSituacao);

        /// <summary>
        /// Cadastra uma nova situação
        /// </summary>
        /// <param name="novaSituacao">Objeto novaSituacao que será cadastrada</param>
        void Cadastrar(Situacao novaSituacao);

        /// <summary>
        /// Atualiza uma situação existente
        /// </summary>
        /// <param name="idSituacao">ID da situação que será atualizada</param>
        /// <param name="situacaoAtualizada">Objeto com as novas informações</param>
        void Atualizar(int idSituacao, Situacao situacaoAtualizada);

        /// <summary>
        /// Deleta uma situacao existente
        /// </summary>
        /// <param name="idSituacao">ID da situação que será deletada</param>
        void Deletar(int idSituacao);
    }
}
