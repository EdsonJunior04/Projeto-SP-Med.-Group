using senai.SpMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Lista todos os médicos
        /// </summary>
        /// <returns>Uma lista de médicos</returns>
        List<Medico> ListarTodas();

        /// <summary>
        /// Busca um médico através do ID
        /// </summary>
        /// <param name="idMedico">ID do médico que será buscado</param>
        /// <returns>Um médico buscado</returns>
        Medico BuscarPorId(int idMedico);
        void ListarTodos();

        /// <summary>
        /// Cadastra um novo médico
        /// </summary>
        /// <param name="novoMedico">Objeto novoMedico que será cadastrado</param>
        void Cadastrar(Medico novoMedico);

        /// <summary>
        /// Atualiza um médico existente
        /// </summary>
        /// <param name="idMedico">ID do médico que será atualizado</param>
        /// <param name="medicoAtualizado">Objeto com as novas informações</param>
        void Atualizar(int idMedico, Medico medicoAtualizado);

        /// <summary>
        /// Deleta um médico existente
        /// </summary>
        /// <param name="idMedico">ID do médico que será deletado</param>
        void Deletar(int idMedico);
    }
}
