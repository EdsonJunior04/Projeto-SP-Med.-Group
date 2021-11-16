using senai_SpMedGroup_webAPI.Context;
using senai_SpMedGroup_webAPI.Domains;
using senai_SpMedGroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void AtualizarUrl(int idTipoUsuario, Tipousuario tipoUsuarioAtualizado)
        {
            Tipousuario tipoUsuario = ctx.Tipousuarios.Find(idTipoUsuario);

            if (tipoUsuario != null)
            {
                tipoUsuario.NomeTipoUsuario = tipoUsuarioAtualizado.NomeTipoUsuario;

                ctx.Update(tipoUsuario);

                ctx.SaveChanges();
            }
        }

        public Tipousuario BuscarPorId(int idTipoUsuario)
        {
            return ctx.Tipousuarios
                .Select(t => new Tipousuario()
                {
                    IdTipoUsuario = t.IdTipoUsuario,
                    NomeTipoUsuario = t.NomeTipoUsuario
                })
                .FirstOrDefault(t => t.IdTipoUsuario == idTipoUsuario);
        }

        public void Cadastrar(Tipousuario novoTipoUsuario)
        {
            ctx.Tipousuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipoUsuario)
        {
            ctx.Tipousuarios.Remove(BuscarPorId(idTipoUsuario));

            ctx.SaveChanges();
        }

        public List<Tipousuario> ListarTodos()
        {
            return ctx.Tipousuarios
                .Select(t => new Tipousuario()
                {
                    IdTipoUsuario = t.IdTipoUsuario,
                    NomeTipoUsuario = t.NomeTipoUsuario
                })
                .ToList();
        }
    }
}
