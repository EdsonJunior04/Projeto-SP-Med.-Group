using senai.SpMedGroup.WebApi.Context;
using senai.SpMedGroup.WebApi.Domains;
using senai.SpMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Repositories
{
    public class MedicoRepository : IMedicoRepository

    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(int idMedico, Medico medicoAtualizado)
        {
            Medico MedicoBuscado = ctx.Medicos.Find(Convert.ToByte(idMedico));

            if (MedicoBuscado != null)
            {
                MedicoBuscado.NomeMedico = medicoAtualizado.NomeMedico;

                ctx.Medicos.Update(MedicoBuscado);

                ctx.SaveChanges();
            }
        }

        public Medico BuscarPorId(int idMedico)
        {
            return ctx.Medicos.FirstOrDefault(e => e.IdClinica == idMedico);
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int idMedico)
        {
            Medico MedicoBuscado = BuscarPorId(idMedico);

            if (MedicoBuscado != null)
            {
                ctx.Medicos.Remove(MedicoBuscado);

                ctx.SaveChanges();
            }
        }

        public List<Medico> ListarTodas()
        {
            return ctx.Medicos.ToList();
        }
    }
}

