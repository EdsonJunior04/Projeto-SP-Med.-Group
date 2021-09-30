using senai.SpMedGroup.WebApi.Context;
using senai.SpMedGroup.WebApi.Domains;
using senai.SpMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(int idTipoUsuario, Tipousuario tipoUsuarioAtualizado)
        {
            Tipousuario TipousuarioBuscado = ctx.Tipousuarios.Find(Convert.ToByte(idTipoUsuario));

            if (TipousuarioBuscado != null)
            {
                TipousuarioBuscado.NomeTipoU = tipoUsuarioAtualizado.NomeTipoU;

                ctx.Tipousuarios.Update(TipousuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public Tipousuario BuscarPorId(int idTipoUsuario)
        {
            return ctx.Tipousuarios.FirstOrDefault(e => e.IdTipoU == idTipoUsuario);
        }

        public void Cadastrar(Tipousuario novoTipoUsuario)
        {
            ctx.Tipousuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipoUsuario)
        {
            Tipousuario TipousuarioBuscado = BuscarPorId(idTipoUsuario);

            if (TipousuarioBuscado != null)
            {
                ctx.Tipousuarios.Remove(TipousuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public List<Tipousuario> Listar()
        {
            return ctx.Tipousuarios.ToList();
        }
    }
}