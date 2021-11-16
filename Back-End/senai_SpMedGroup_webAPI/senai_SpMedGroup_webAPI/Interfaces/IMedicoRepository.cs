using senai_SpMedGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webAPI.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Lista todos os Medicos
        /// </summary>
        /// <returns></returns>
        List<Medico> ListarTodos();

        /// <summary>
        /// Busca um Medico através do id
        /// </summary>
        /// <param name="idMedico">Id do Medico a ser buscado</param>
        /// <returns></returns>
        Medico BuscarPorId(int idMedico);

        /// <summary>
        /// Cadastra um novo Medico
        /// </summary>
        /// <param name="novoMedico">Objeto Medico a ser cadastrado</param>
        bool Cadastrar(Medico novoMedico);

        /// <summary>
        /// Deleta um Medico através do id
        /// </summary>
        /// <param name="idMedico">Id do Medico a ser deletado</param>
        void Deletar(int idMedico);

        /// <summary>
        /// Atualiza um Medico através do id
        /// </summary>
        /// <param name="idMedico">Id do Medico a ser atualizado</param>
        /// <param name="MedicoAtualizado">Objeto Medico a ser atualizado</param>
        void AtualizarUrl(int idMedico, Medico MedicoAtualizado);
    }
}
