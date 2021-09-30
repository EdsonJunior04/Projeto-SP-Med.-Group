using senai.SpMedGroup.WebApi.Context;
using senai.SpMedGroup.WebApi.Domains;
using senai.SpMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(int idConsulta, Consulta consultaAtualizada)
        {
           Consulta ConsultaBuscada = ctx.Consultas.Find(Convert.ToByte(idConsulta));

            if (ConsultaBuscada != null)
            {
                ConsultaBuscada.IdConsulta = consultaAtualizada.IdConsulta;

                ctx.Consultas.Update(ConsultaBuscada);

                ctx.SaveChanges();
            }
        }

        public Consulta BuscarPorId(int idConsulta)
        {
            return ctx.Consultas.FirstOrDefault(e => e.IdConsulta == idConsulta);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            ctx.Consultas.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int idConsulta)
        {
            Consulta ConsultaBuscada = BuscarPorId(idConsulta);

            if (ConsultaBuscada != null)
            {
                ctx.Consultas.Remove(ConsultaBuscada);

                ctx.SaveChanges();
            }
        }

        public List<Consulta> ListarTodas()
        {
            return ctx.Consultas.ToList();
        }
    }
}
