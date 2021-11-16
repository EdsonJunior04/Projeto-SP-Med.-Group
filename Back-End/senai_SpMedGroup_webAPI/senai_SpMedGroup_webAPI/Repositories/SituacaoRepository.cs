using senai_SpMedGroup_webAPI.Context;
using senai_SpMedGroup_webAPI.Domains;
using senai_SpMedGroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webAPI.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void AtualizarUrl(int idSituacao, Situacao SituacaoAtualizada)
        {
            throw new NotImplementedException();
        }

        public Situacao BuscarPorId(int idSituacao)
        {
            return ctx.Situacaos.FirstOrDefault(u => u.IdSituacao == idSituacao);
        }

        public void Cadastrar(Situacao novaSituacao)
        {
            ctx.Situacaos.Add(novaSituacao);

            ctx.SaveChanges();
        }

        public void Deletar(int idSituacao)
        {
            ctx.Situacaos.Remove(BuscarPorId(idSituacao));

            ctx.SaveChanges();
        }

        public List<Situacao> ListarTodos()
        {
            return ctx.Situacaos.ToList();
        }
    }
}
