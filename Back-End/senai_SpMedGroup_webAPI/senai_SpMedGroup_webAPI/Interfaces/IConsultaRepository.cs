using senai_SpMedGroup_webAPI.Domains;
using senai_SpMedGroup_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webAPI.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// Lista todos as Consultas
        /// </summary>
        /// <returns></returns>
        List<Consulta> ListarTodos();

        /// <summary>
        /// Busca uma Consulta através do id
        /// </summary>
        /// <param name="idConsulta">Id da Consulta a ser buscada</param>
        /// <returns></returns>
        Consulta BuscarPorId(int idConsulta);

        /// <summary>
        /// Cadastra uma nova Consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto Consulta a ser cadastrado</param>
        void Cadastrar(Consulta novaConsulta);

        /// <summary>
        /// Deleta uma Consulta através do id
        /// </summary>
        /// <param name="idConsulta">Id da Consulta a ser deletada</param>
        void Deletar(int idConsulta);

        /// <summary>
        /// Atualiza uma Consulta através do id
        /// </summary>
        /// <param name="idConsulta">Id da Consulta a ser atualizada</param>
        /// <param name="consultaAtualizada">Objeto Consulta a ser atualizado</param>
        void AtualizarUrl(int idConsulta, Consulta consultaAtualizada);

        /// <summary>
        /// Cancela uma consulta
        /// </summary>
        /// <param name="idConsulta">Id da consulta a ser cancelada</param>
        bool Cancelar(int idConsulta);

        /// <summary>
        /// Atualiza a situação de um consulta
        /// </summary>
        /// <param name="idConsulta">Id da consulta a ser atualizada</param>
        /// <param name="status">Situação da consulta</param>
        bool AlterarSituacao(int idConsulta, string status);

        /// <summary>
        /// Atualiza a descrição de uma consulta através do seu id
        /// </summary>
        /// <param name="idConsulta">Id da consulta a ser atualizada</param>
        /// <param name="idUserMedico">Id do usuario do médico que modificou a descrição</param>
        /// <param name="consulta">Objeto consulta com a descrição atualizada</param>
        /// <returns></returns>
        bool AtualizarDescricao(int idConsulta, int idUserMedico, DescricaoViewModel consulta);

        /// <summary>
        /// Lista as consuldas de um Usuario
        /// </summary>
        /// <param name="idUsuario">Id do usuario a ser listada as consultas</param>
        /// <returns></returns>
        List<Consulta> VerMinhas(int idUsuario);
    }
}
