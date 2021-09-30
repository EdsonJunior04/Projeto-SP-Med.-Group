using Microsoft.EntityFrameworkCore;
using senai.SpMedGroup.WebApi.Context;
using senai.SpMedGroup.WebApi.Domains;
using senai.SpMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {


            Usuario usuarioBuscado = ctx.Usuarios.Find(idUsuario);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.IdUsuario = usuarioAtualizado.IdUsuario;

                usuarioBuscado.Email = usuarioAtualizado.Email;

                usuarioBuscado.Senha = usuarioAtualizado.Senha;

                ctx.Usuarios.Update(usuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            Usuario usuarioBuscado = ctx.Usuarios.FirstOrDefault(c => c.Email == email && c.Senha == senha);

            return (usuarioBuscado);
        }

        public Usuario BuscarPorId(int idUsuario)
        {

            // Retorna um usuario encontrado com o id informado
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            // Adiciona este novoEstudio
            ctx.Usuarios.Add(novoUsuario);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {

            Usuario usuarioBuscado = BuscarPorId(idUsuario);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public List<Usuario> ListarComTipo()
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }

        public List<Usuario> ListarTudo()
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation)
                 .Include(u => u.Pacientes).ToList();
        }
    }
}
