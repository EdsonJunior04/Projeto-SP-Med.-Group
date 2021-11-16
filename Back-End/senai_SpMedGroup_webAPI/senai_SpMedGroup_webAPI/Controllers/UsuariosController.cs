using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um usuário através do id
        /// </summary>
        /// <param name="id">Id do usuário a ser buscado</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
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

                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo usuário (Paciente)
        /// </summary>
        /// <param name="novoUsuarioModel">Dados do usário a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(UsuarioViewModel novoUsuarioModel)
        {
            try
            {
                Usuario novoUsuario = new Usuario()
                {
                    IdTipoUsuario = 1,
                    NomeUsuario = novoUsuarioModel.NomeUsuario,
                    Email = novoUsuarioModel.Email,
                    Senha = novoUsuarioModel.Senha,
                };

                _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo usuário (administrador, médico, ou paciente)
        /// </summary>
        /// <param name="novoUsuario">Dados do usuário administrador</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPost("post/adm")]
        public IActionResult PostAdm(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um usuário através do id
        /// </summary>
        /// <param name="id">Id do usuário a ser deletado</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
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

                _usuarioRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
