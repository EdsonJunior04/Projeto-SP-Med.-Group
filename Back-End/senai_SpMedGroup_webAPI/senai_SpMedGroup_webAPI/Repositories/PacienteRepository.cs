using senai_SpMedGroup_webAPI.Context;
using senai_SpMedGroup_webAPI.Domains;
using senai_SpMedGroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webAPI.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void AtualizarUrl(int idPaciente, Paciente PacienteAtualizado)
        {
            throw new NotImplementedException();
        }

        public Paciente BuscarPorId(int idPaciente)
        {
            return ctx.Pacientes.FirstOrDefault(u => u.IdPaciente == idPaciente);
        }

        public bool Cadastrar(Paciente novoPaciente)
        {
            int? idUser = novoPaciente.IdUsuario;

            Usuario User = ctx.Usuarios.Find(idUser);

            if (User.IdTipoUsuario == 1)
            {
                if (User.Pacientes.Count == 0)
                {
                    ctx.Pacientes.Add(novoPaciente);

                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;
        }

        public void Deletar(int idPaciente)
        {
            Paciente pacienteBuscado = BuscarPorId(idPaciente);

            Usuario userPaciente = ctx.Usuarios.Find(pacienteBuscado.IdUsuario);

            ctx.Usuarios.Remove(userPaciente);

            ctx.Pacientes.Remove(pacienteBuscado);

            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes.ToList();
        }
    }
}
