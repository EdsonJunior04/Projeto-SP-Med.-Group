using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_SpMedGroup_webAPI.Domains;
using senai_SpMedGroup_webAPI.Interfaces;
using senai_SpMedGroup_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Listar todas as clinicas cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Clinica> lista = _clinicaRepository.ListarTodos();

                return Ok(lista);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastrar uma nova Clinica
        /// </summary>
        /// <param name="novaClinica">Objeto de nova clinica com dados a serem cadastrados</param>
        /// <returns></returns>
        [Authorize(Roles ="2")]
        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(novaClinica);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta uma clinica através do id
        /// </summary>
        /// <param name="id">Id da clinica a ser deletada</param>
        /// <returns></returns>
        [Authorize (Roles ="2")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound(
                    new
                    {
                        mensagem = "Id inválido",
                        erro = true
                    }
                    );
            }

            try
            {
                bool deleted = _clinicaRepository.Deletar(id);

                if (deleted) return NoContent();

                return NotFound(
                    new
                    {
                        mensagem = "Clinica não encontrada",
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
