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
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }

        public PacientesController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_pacienteRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="novoPaciente">Dados do paciente a ser cadastrado</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Paciente novoPaciente)
        {
            try
            {
                bool created = _pacienteRepository.Cadastrar(novoPaciente);

                if (created) return StatusCode(201);

                return NotFound(
                        new
                        {
                            mensagem = "Usuario precisa ser do tipo paciente e não estar vinculado a outro paciente",
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
