using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.SpMedGroup.WebApi.Domains;
using senai.SpMedGroup.WebApi.Interfaces;
using senai.SpMedGroup.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_UsuarioRepository.Listar());
        }

        [Authorize(Roles = "2, 3")]
        [HttpGet("ListarMinhasConsultas")]

        public IActionResult ListarMinhasConsultas()
        {
            int idUsuarioLogado = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

            return Ok(_UsuarioRepository.ListarMinhasConsultas(idUsuarioLogado));
        }


        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            _UsuarioRepository.Cadastrar(novoUsuario);
            return StatusCode(201);
        }

        [HttpPut("{idUsuario}")]
        public IActionResult Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            _UsuarioRepository.Atualizar(idUsuario, usuarioAtualizado);
            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _UsuarioRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPost("{foto_perfil}")]
        public IActionResult SalvarFotoBD(IFormFile arquivo)
        {
            try
            {
                if (arquivo.Length > 250000)

                    return BadRequest(new { mensagem = "Tamanho maximo excedido;" });

                string extensao = arquivo.FileName.Split('.').Last();

                if (extensao != "jpg")

                    return BadRequest(new { mensagem = "Insira um arquivo .jpg" });

                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);


                _UsuarioRepository.SalvarFotoBD(arquivo, idUsuario);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("foto_perfil")]
        public IActionResult CarregarFoto()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                string base64 = _UsuarioRepository.CarregarFotoBD(idUsuario);

                return Ok(base64);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
