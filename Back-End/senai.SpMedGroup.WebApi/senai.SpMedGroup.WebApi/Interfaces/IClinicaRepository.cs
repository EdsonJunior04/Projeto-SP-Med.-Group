using senai.SpMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Interfaces
{
    interface IClinicaRepository
    {
        /// <summary>
        /// Lista todas as clínicas 
        /// </summary>
        /// <returns>Uma lista de clínicas</returns>
        List<Clinica> ListarTodas();

        /// <summary>
        /// Busca uma clínica através do ID
        /// </summary>
        /// <param name="idClinica">ID da clínica que será buscada</param>
        /// <returns>Uma consulta buscada</returns>
        Clinica BuscarPorId(int idClinica);

        /// <summary>
        /// Cadastra uma nova clínica
        /// </summary>
        /// <param name="novaClinica">Objeto novaClinica que será cadastrada</param>
        void Cadastrar(Clinica novaClinica);

        /// <summary>
        /// Atualiza uma clínica existente
        /// </summary>
        /// <param name="idClinica">ID da clínica que será atualizada</param>
        /// <param name="consultaAtualizada">Objeto com as novas informações</param>
        void Atualizar(int idClinica, Clinica clinicaAtualizada);

        /// <summary>
        /// Deleta uma clínica existente
        /// </summary>
        /// <param name="idClínica">ID da clínica que será deletada</param>
        void Deletar(int idClinica);
    }
}
