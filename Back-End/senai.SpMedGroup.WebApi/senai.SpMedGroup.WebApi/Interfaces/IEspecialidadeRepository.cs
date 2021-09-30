using senai.SpMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        /// <summary>
        /// Lista todos as especialidade
        /// </summary>
        /// <returns>Uma lista de especialidade</returns>
        List<Especialidade> ListarTodas();

        /// <summary>
        /// Busca uma especialidade através do ID
        /// </summary>
        /// <param name="idEspecialidade">ID da especialidade que será buscada</param>
        /// <returns>Uma especialidade buscada</returns>
        Especialidade BuscarPorId(int idEspecialidade);

        /// <summary>
        /// Cadastra uma nova especialidade
        /// </summary>
        /// <param name="novaEspecialidade">Objeto novaEspecialidade que será cadastrada</param>
        void Cadastrar(Especialidade novaEspecialidade);

        /// <summary>
        /// Atualiza uma especialidade existente
        /// </summary>
        /// <param name="idEspecialidade">ID da especialidade que será atualizada</param>
        /// <param name="especialidadeAtualizada">Objeto com as novas informações</param>
        void Atualizar(int idEspecialidade, Especialidade especialidadeAtualizada);

        /// <summary>
        /// Deleta uma especialidade existente
        /// </summary>
        /// <param name="idEspecialidade">ID da especialidade que será deletada</param>
        void Deletar(int idEspecialidade);
    }
}
