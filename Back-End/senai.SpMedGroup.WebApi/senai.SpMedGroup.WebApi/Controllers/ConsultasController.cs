using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.SpMedGroup.WebApi.Domains;
using senai.SpMedGroup.WebApi.Interfaces;
using senai.SpMedGroup.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns>Status Code 200 - OK, com todas as consultas cadastradas</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_consultaRepository.ListarTodas());
        }

        /// <summary>
        /// Lista uma consulta por meio de seu Id
        /// </summary>
        /// <param name="idConsulta">Id da consulta que deseja visualizar</param>
        /// <returns>Status Code 200 - OK, com a consulta correspondente ao Id informado</returns>
        [HttpGet("{idConsulta}")]
        public IActionResult BuscarPorID(int idConsulta)
        {
            return Ok(_consultaRepository.BuscarPorId(idConsulta));
        }

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Consultas com informações atualizadas</param>
        /// <returns>Status Code 201 - Created, Confirmação padrao</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Consulta novaConsulta)
        {
            _consultaRepository.Cadastrar(novaConsulta);
            return StatusCode(201);
        }

        /// <summary>
        /// Cancela uma consulta existente, localizando-a por seu Id
        /// </summary>
        /// <param name="idConsulta">Id da consulta que deja cancelar</param>
        /// <returns>Status Code 204 - Sucesso</returns>
        [Authorize(Roles = "1")]
        [HttpPatch("{idConsulta}")]
        public IActionResult CancelarConsulta(int idConsulta)
        {
            _consultaRepository.CancelarConsulta(idConsulta);

            return StatusCode(204);
        }

        /// <summary>
        /// Exclui uma consulta do banco de dados
        /// </summary>
        /// <param name="id">Id correspondente a consulta que deseja excluir</param>
        /// <returns>Status Code 204 - Sucesso</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _consultaRepository.Deletar(id);

            return StatusCode(204);
        }



        [Authorize(Roles = "2")]
        [HttpPatch("descricao/{idConsulta}")]

        public IActionResult IncluirDescricao(int idConsulta, ConsultaViewModel descricaoAtualizada)
        {
            _consultaRepository.IncluirDescricao(idConsulta, descricaoAtualizada);
            return StatusCode(204);
        }

    }
}
