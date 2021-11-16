using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using senai_SpMedGroup_webAPI.Domains;
using senai_SpMedGroup_webAPI.Interfaces;
using senai_SpMedGroup_webAPI.Repositories;
using senai_SpMedGroup_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Listar todas as consultas
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Consulta> lista = _consultaRepository.ListarTodos();

                return Ok(lista);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastrar uma nova consulta (Agendar consulta)
        /// </summary>
        /// <param name="novaconsultaModel">Dados da consulta a ser agendada</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(ConsultaViewModel novaconsultaModel)
        {
            try
            {
                Consulta novaConsulta = new Consulta()
                {
                    IdSituacao = 3,
                    IdPaciente = novaconsultaModel.IdPaciente,
                    IdMedico = novaconsultaModel.IdMedico,
                    DataConsulta = novaconsultaModel.DataConsulta
                };

                _consultaRepository.Cadastrar(novaConsulta);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cancelar uma consulta através do seu id
        /// </summary>
        /// <param name="id">Id da consulta a ser cancelada</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPatch("cancelar/{id}")]
        public IActionResult Cancel(int id)
        {
            try
            {
                bool created = _consultaRepository.Cancelar(id);

                if (created)
                {
                    return NoContent();
                }
                return NotFound(
                    new
                    {
                        mensagem = "Consulta não encontrada ou já realizada",
                        erro = true
                    }
                    );
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Alterar a situação da consulta através do seu id
        /// </summary>
        /// <param name="idConsulta">id da consulta que terá a situação alterada</param>
        /// <param name="consultaModel">Nova situação da consulta</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPatch("alterar/situacao/{idConsulta")]
        public IActionResult AlterSituation(int idConsulta, SituacaoViewModel consultaModel)
        {
            if (consultaModel.IdSituacao <= 0 || consultaModel.IdSituacao > 3)
            {
                return NotFound(
                    new
                    {
                        mensagem = "Id da situação invalido",
                        erro = true
                    }
                    );
            }

            try
            {
                _consultaRepository.AlterarSituacao(idConsulta, consultaModel.IdSituacao.ToString());

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Lista as consultas relacionadas a um determinado usuário (médico ou paciente)
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "3,1")]
        [HttpGet("minhas")]
        public IActionResult GetMyOwn()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.VerMinhas(idUsuario));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        [Authorize(Roles = "3")]
        [HttpPatch("alterar/descricao/{idConsulta}")]
        public IActionResult AlterDescription(int idConsulta, DescricaoViewModel descricao)
        {
            try
            {
                if (idConsulta <= 0)
                {
                    return NotFound(
                        new
                        {
                            mensagem = "Id inválido",
                            erro = true
                        }
                        );
                }
                int idUserMedico = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                bool altered = _consultaRepository.AtualizarDescricao(idConsulta, idUserMedico, descricao);

                if (altered) return NoContent();

                return NotFound(
                    new
                    {
                        mensagem = "Consultas não encontrada ou Médico não responsável pela consulta",
                        erro = true
                    }
                    );
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}