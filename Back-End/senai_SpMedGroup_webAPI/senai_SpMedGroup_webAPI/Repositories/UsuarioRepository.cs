using Microsoft.AspNetCore.Http;
using senai_SpMedGroup_webAPI.Context;
using senai_SpMedGroup_webAPI.Domains;
using senai_SpMedGroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void AtualizarUrl(int idUsuario, Usuario UsuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios
                .Select(u => new Usuario()
                {
                    IdUsuario = u.IdUsuario,
                    NomeUsuario = u.NomeUsuario,
                    Email = u.Email,
                    IdTipoUsuarioNavigation = new Tipousuario()
                    {
                        IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                        NomeTipoUsuario = u.IdTipoUsuarioNavigation.NomeTipoUsuario,
                    },
                    Medicos = u.Medicos,
                    Pacientes = u.Pacientes
                })
                .FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public string ConsultarFotoDir(int idUsuario)
        {
            string nomeArquivo = idUsuario.ToString() + ".png";

            string caminho = Path.Combine("perfil", nomeArquivo);

            if (File.Exists(caminho))
            {
                byte[] bytesArquivo = File.ReadAllBytes(caminho);

                return Convert.ToBase64String(bytesArquivo);
            }
            return null;
        }

        public void Deletar(int idUsuario)
        {
            Usuario usuarioBuscado = BuscarPorId(idUsuario);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios
                .Select(u => new Usuario()
                {
                    IdUsuario = u.IdUsuario,
                    NomeUsuario = u.NomeUsuario,
                    Email = u.Email,
                    IdTipoUsuarioNavigation = new Tipousuario()
                    {
                        IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                        NomeTipoUsuario = u.IdTipoUsuarioNavigation.NomeTipoUsuario,
                    },
                    Medicos = u.Medicos,
                    Pacientes = u.Pacientes
                })
                .ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public void SalvarPerfilDir(IFormFile foto, int idUsuario)
        {
            string nomeArquivo = idUsuario.ToString() + ".png";

            if (!Directory.Exists("perfil"))
            {
                Directory.CreateDirectory("perfil");
            }

            using (var stream = new FileStream(Path.Combine("perfil", nomeArquivo), FileMode.Create))
            {
                foto.CopyTo(stream);
            }
        }
    }
}
