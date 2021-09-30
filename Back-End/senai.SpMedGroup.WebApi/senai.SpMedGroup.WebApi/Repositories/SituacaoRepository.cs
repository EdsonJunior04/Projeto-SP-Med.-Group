using senai.SpMedGroup.WebApi.Context;
using senai.SpMedGroup.WebApi.Domains;
using senai.SpMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(int idSituacao, Situacao situacaoAtualizada)
        {
            Situacao SituacaoBuscado = ctx.Situacoes.Find(Convert.ToByte(idSituacao));

            if (SituacaoBuscado != null)
            {
                SituacaoBuscado.NomeSituacao = situacaoAtualizada.NomeSituacao;

                ctx.Situacoes.Update(SituacaoBuscado);

                ctx.SaveChanges();
            }
        }

        public Situacao BuscarPorId(int idSituacao)
        {
            return ctx.Situacoes.FirstOrDefault(e => e.IdSituacao == idSituacao);
        }

        public void Cadastrar(Situacao novaSituacao)
        {
            ctx.Situacoes.Add(novaSituacao);

            ctx.SaveChanges();
        }

        public void Deletar(int idSituacao)
        {
            Situacao SituacaoBuscado = BuscarPorId(idSituacao);

            if (SituacaoBuscado != null)
            {
                ctx.Situacoes.Remove(SituacaoBuscado);

                ctx.SaveChanges();
            }
        }

        public List<Situacao> ListarTodas()
        {
            return ctx.Situacoes.ToList();
        }
    }
}
