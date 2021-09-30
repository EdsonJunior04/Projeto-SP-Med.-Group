using senai.SpMedGroup.WebApi.Context;
using senai.SpMedGroup.WebApi.Domains;
using senai.SpMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(int idClinica, Clinica clinicaAtualizada)
        {
            Clinica ClinicaBuscada = ctx.Clinicas.Find(Convert.ToByte(idClinica));

            if (ClinicaBuscada != null)
            {
                ClinicaBuscada.NomeClinica = clinicaAtualizada.NomeClinica;

                ctx.Clinicas.Update(ClinicaBuscada);

                ctx.SaveChanges();
            }
        }

        public Clinica BuscarPorId(int idClinica)
        {
            return ctx.Clinicas.FirstOrDefault(e => e.IdClinica == idClinica);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int idClinica)
        {
            Clinica ClinicaBuscada = BuscarPorId(idClinica);

            if (ClinicaBuscada != null)
            {
                ctx.Clinicas.Remove(ClinicaBuscada);

                ctx.SaveChanges();
            }
        }

        public List<Clinica> ListarTodas()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
