using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.SpMedGroup.WebApi.Domains;
using senai.SpMedGroup.WebApi.Interfaces;
using senai.SpMedGroup.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginsController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.ValidarEmailSenha(login.Email, login.Senha);

                if (usuarioBuscado == null)

                    return NotFound("Email ou senha invalidos");

                // Caso o usuario seja encontrado, prossegue para a criação do token

                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoU.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SPMedicalGroup-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken
                    (
                        issuer: "SPMedicalGroup.webAPI",
                        audience: "SPMedicalGroup.webAPI",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddMinutes(15),
                        signingCredentials: creds
                    );

                return Ok
                    (
                        new { Token = new JwtSecurityTokenHandler().WriteToken(meuToken) }
                    );

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}