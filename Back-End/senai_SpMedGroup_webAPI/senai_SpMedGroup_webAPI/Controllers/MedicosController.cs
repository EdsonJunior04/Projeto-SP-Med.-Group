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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Lista todos os médicos
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_medicoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Lista um médico através do id
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_medicoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        /// <summary>
        /// Cadastra um novo médico
        /// </summary>
        /// <param name="novoMedico">Dados do médico a ser cadastrado</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Medico novoMedico)
        {
            try
            {
                bool created = _medicoRepository.Cadastrar(novoMedico);

                if (created) return StatusCode(201);

                return NotFound(
                        new
                        {
                            mensagem = "Usuario precisa ser do tipo médico e não estar vinculado a outro médico",
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
        /// Deleta um médico
        /// </summary>
        /// <param name="id">Id do médico a ser deletado</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
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
                _medicoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
