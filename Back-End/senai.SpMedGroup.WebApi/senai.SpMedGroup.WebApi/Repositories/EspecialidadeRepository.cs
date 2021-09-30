using senai.SpMedGroup.WebApi.Context;
using senai.SpMedGroup.WebApi.Domains;
using senai.SpMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(int idEspecialidade, Especialidade especialidadeAtualizada)
        {
            Especialidade EspecialidadeBuscado = ctx.Especialidades.Find(Convert.ToByte(idEspecialidade));

            if (EspecialidadeBuscado != null)
            {
                EspecialidadeBuscado.NomeEspecialidade = especialidadeAtualizada.NomeEspecialidade;

                ctx.Especialidades.Update(EspecialidadeBuscado);

                ctx.SaveChanges();
            }
        }

        public Especialidade BuscarPorId(int idEspecialidade)
        {
            return ctx.Especialidades.FirstOrDefault(e => e.IdEspecialidade == idEspecialidade);
        }

        public void Cadastrar(Especialidade novaEspecialidade)
        {
            ctx.Especialidades.Add(novaEspecialidade);

            ctx.SaveChanges();
        }

        public void Deletar(int idEspecialidade)
        {
            Especialidade EspecialidadeBuscado = BuscarPorId(idEspecialidade);

            if (EspecialidadeBuscado != null)
            {
                ctx.Especialidades.Remove(EspecialidadeBuscado);

                ctx.SaveChanges();
            }
        }

        public List<Especialidade> ListarTodas()
        {
            return ctx.Especialidades.ToList();
        }
    }
}
