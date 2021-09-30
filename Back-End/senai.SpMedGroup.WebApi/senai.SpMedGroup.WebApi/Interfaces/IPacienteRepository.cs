using senai.SpMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns>Uma lista de pacientes</returns>
        List<Paciente> ListarTodas();

        /// <summary>
        /// Busca um paciente através do ID
        /// </summary>
        /// <param name="idPaciente">ID do paciente que será buscado</param>
        /// <returns>Um paciente buscado</returns>
        Paciente BuscarPorId(int idPaciente);
        void ListarTodos();

        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="novoPaciente">Objeto novoPaciente que será cadastrado</param>
        void Cadastrar(Paciente novoPaciente);

        /// <summary>
        /// Atualiza um paciente existente
        /// </summary>
        /// <param name="idPaciente">ID da paciente que será atualizado</param>
        /// <param name="pacienteAtualizado">Objeto com as novas informações</param>
        void Atualizar(int idPaciente, Paciente pacienteAtualizado);

        /// <summary>
        /// Deleta um paciente existente
        /// </summary>
        /// <param name="idPaciente">ID do paciente que será deletado</param>
        void Deletar(int idPaciente);
    }
}
