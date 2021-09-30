using senai.SpMedGroup.WebApi.Context;
using senai.SpMedGroup.WebApi.Domains;
using senai.SpMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(int idPaciente, Paciente pacienteAtualizado)
        {
            Paciente PacienteBuscado = ctx.Pacientes.Find(Convert.ToByte(idPaciente));

            if (PacienteBuscado != null)
            {
                PacienteBuscado.NomePaciente = pacienteAtualizado.NomePaciente;

                ctx.Pacientes.Update(PacienteBuscado);

                ctx.SaveChanges();
            }
        }

        public Paciente BuscarPorId(int idPaciente)
        {
            return ctx.Pacientes.FirstOrDefault(e => e.IdPaciente == idPaciente);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);

            ctx.SaveChanges();
        }

        public void Deletar(int idPaciente)
        {
            Paciente PacienteBuscado = BuscarPorId(idPaciente);

            if (PacienteBuscado != null)
            {
                ctx.Pacientes.Remove(PacienteBuscado);

                ctx.SaveChanges();
            }
        }

        public List<Paciente> ListarTodas()
        {
            return ctx.Pacientes.ToList();
        }
    }
}
