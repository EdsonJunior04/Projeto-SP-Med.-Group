﻿using senai_SpMedGroup_webAPI.Context;
using senai_SpMedGroup_webAPI.Domains;
using senai_SpMedGroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webAPI.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void AtualizarUrl(int idMedico, Medico MedicoAtualizado)
        {
            throw new NotImplementedException();
        }

        public Medico BuscarPorId(int idMedico)
        {
            return ctx.Medicos
                .Select(c => new Medico()
                {
                    IdMedico = c.IdMedico,
                    IdUsuario = c.IdUsuario,
                    Crm = c.Crm,
                    NomeMedico = c.NomeMedico,
                    IdClinicaNavigation = new Clinica()
                    {
                        NomeFantasia = c.IdClinicaNavigation.NomeFantasia,
                        Cnpj = c.IdClinicaNavigation.Cnpj,
                        RazaoSocial = c.IdClinicaNavigation.RazaoSocial,
                        Endereco = c.IdClinicaNavigation.Endereco,
                        Telefone = c.IdClinicaNavigation.Telefone,
                        Email = c.IdClinicaNavigation.Email,
                    },
                    IdEspecialidadeNavigation = new Especialidade()
                    {
                        NomeEspecialidade = c.IdEspecialidadeNavigation.NomeEspecialidade
                    },
                    IdUsuarioNavigation = new Usuario()
                    {
                        NomeUsuario = c.IdUsuarioNavigation.NomeUsuario,
                        Email = c.IdUsuarioNavigation.Email
                    }
                })
                .FirstOrDefault(u => u.IdMedico == idMedico);
        }

        public bool Cadastrar(Medico novoMedico)
        {
            int? idUser = (int?)novoMedico.IdUsuario;

            Usuario user = ctx.Usuarios.Find(Convert.ToInt32(idUser));

            if (user.IdTipoUsuario == 3)
            {
                if (user.Medicos.Count == 0)
                {
                    ctx.Medicos.Add(novoMedico);

                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;

        }

        public void Deletar(int idMedico)
        {
            Medico medicoBuscado = BuscarPorId(idMedico);

            Usuario userMedico = ctx.Usuarios.Find(medicoBuscado.IdUsuario);

            ctx.Usuarios.Remove(userMedico);

            ctx.Medicos.Remove(medicoBuscado);

            ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos
                .Select(c => new Medico()
                {
                    IdMedico = c.IdMedico,
                    IdUsuario = c.IdUsuario,
                    Crm = c.Crm,
                    NomeMedico = c.NomeMedico,
                    IdClinicaNavigation = new Clinica()
                    {
                        NomeFantasia = c.IdClinicaNavigation.NomeFantasia,
                        Cnpj = c.IdClinicaNavigation.Cnpj,
                        RazaoSocial = c.IdClinicaNavigation.RazaoSocial,
                        Endereco = c.IdClinicaNavigation.Endereco,
                        Telefone = c.IdClinicaNavigation.Telefone,
                        Email = c.IdClinicaNavigation.Email,
                    },
                    IdEspecialidadeNavigation = new Especialidade()
                    {
                        NomeEspecialidade = c.IdEspecialidadeNavigation.NomeEspecialidade
                    },
                    IdUsuarioNavigation = new Usuario()
                    {
                        NomeUsuario = c.IdUsuarioNavigation.NomeUsuario,
                        Email = c.IdUsuarioNavigation.Email
                    }
                })
                .ToList();
        }

        public List<Medico> ListarComUsuario()
        {
            return ctx.Medicos

                .ToList();
        }

    }
}
