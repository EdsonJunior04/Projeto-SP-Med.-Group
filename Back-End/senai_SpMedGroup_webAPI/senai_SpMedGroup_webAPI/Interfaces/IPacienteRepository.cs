using senai_SpMedGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webAPI.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// Lista todos os Pacientes
        /// </summary>
        /// <returns></returns>
        List<Paciente> ListarTodos();

        /// <summary>
        /// Busca um Paciente através do id
        /// </summary>
        /// <param name="idPaciente">Id do Paciente a ser buscado</param>
        /// <returns></returns>
        Paciente BuscarPorId(int idPaciente);

        /// <summary>
        /// Cadastra um novo Paciente
        /// </summary>
        /// <param name="novoPaciente">Objeto Paciente a ser cadastrado</param>
        bool Cadastrar(Paciente novoPaciente);

        /// <summary>
        /// Deleta um Paciente através do id
        /// </summary>
        /// <param name="idPaciente">Id do Paciente a ser deletado</param>
        void Deletar(int idPaciente);

        /// <summary>
        /// Atualiza um Paciente através do id
        /// </summary>
        /// <param name="idPaciente">Id do Paciente a ser atualizado</param>
        /// <param name="PacienteAtualizado">Objeto Paciente a ser atualizado</param>
        void AtualizarUrl(int idPaciente, Paciente PacienteAtualizado);
    }
}
