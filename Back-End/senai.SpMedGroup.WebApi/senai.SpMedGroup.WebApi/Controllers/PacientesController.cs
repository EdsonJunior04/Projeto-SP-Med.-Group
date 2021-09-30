using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }


        public PacientesController()
        {
            _pacienteRepository = new PacienteRepository();
        }


        [Authorize]
        [HttpGet]
        public IActionResult ListasTodos()
        {
            _pacienteRepository.ListarTodos();
            return Ok(200);
        }
    }
}
