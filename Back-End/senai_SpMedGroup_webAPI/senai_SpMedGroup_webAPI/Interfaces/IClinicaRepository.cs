using senai_SpMedGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webAPI.Interfaces
{
    interface IClinicaRepository
    {
        /// <summary>
        /// Lista todos as Clinicas
        /// </summary>
        /// <returns></returns>
        List<Clinica> ListarTodos();

        /// <summary>
        /// Busca uma Clinica através do id
        /// </summary>
        /// <param name="idClinica">Id da Clinica a ser buscada</param>
        /// <returns></returns>
        Clinica BuscarPorId(int idClinica);

        /// <summary>
        /// Cadastra uma nova Clinica
        /// </summary>
        /// <param name="novaClinica">Objeto Clinica a ser cadastrado</param>
        void Cadastrar(Clinica novaClinica);

        /// <summary>
        /// Deleta uma Clinica através do id
        /// </summary>
        /// <param name="idClinica">Id da Clinica a ser deletada</param>
        bool Deletar(int idClinica);

        /// <summary>
        /// Atualiza uma Clinica através do id
        /// </summary>
        /// <param name="idClinica">Id da Clinica a ser atualizada</param>
        /// <param name="ClinicaAtualizada">Objeto Clinica a ser atualizado</param>
        void AtualizarUrl(int idClinica, Clinica ClinicaAtualizada);
    }
}
