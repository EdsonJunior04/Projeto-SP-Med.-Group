using senai_SpMedGroup_webAPI.Context;
using senai_SpMedGroup_webAPI.Domains;
using senai_SpMedGroup_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webAPI.Repositories
{
    public class ConsultaRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public bool AtualizarDescricao(int idConsulta, int idUserMedico, DescricaoViewModel consulta)
        {
            Consulta consultaBuscada = ctx.Consulta.FirstOrDefault(p => p.IdConsulta == idConsulta);

            Medico medico = ctx.Medicos.FirstOrDefault(m => m.IdUsuario == idUserMedico);

            if (consultaBuscada == null) return false;
            if (medico.IdMedico != consultaBuscada.IdMedico) return false;

            consultaBuscada.Descricao = consulta.Descricao;
            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();

            return true;
        }

        public bool AlterarSituacao(int idConsulta, string status)
        {
            Consulta consultaBuscada = ctx.Consulta.FirstOrDefault(p => p.IdConsulta == idConsulta);

            if (consultaBuscada == null) return false;

            switch (status)
            {
                case "1":
                    consultaBuscada.IdSituacao = 1;
                    break;
                case "2":
                    consultaBuscada.IdSituacao = 2;
                    break;
                case "3":
                    consultaBuscada.IdSituacao = 3;
                    break;
                default:
                    consultaBuscada.IdSituacao = consultaBuscada.IdSituacao;
                    break;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();

            return true;
        }

        public void AtualizarUrl(int idConsulta, Consulta consultaAtualizada)
        {
            throw new NotImplementedException();
        }

        public Consulta BuscarPorId(int idConsulta)
        {
            return ctx.Consulta.FirstOrDefault(u => u.IdConsulta == idConsulta);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public bool Cancelar(int idConsulta)
        {
            Consulta consultaBuscada = ctx.Consulta.FirstOrDefault(p => p.IdConsulta == idConsulta);

            if (consultaBuscada != null)
            {
                if (consultaBuscada.IdSituacao == 1) return false;

                consultaBuscada.IdSituacao = 2;

                ctx.Consulta.Update(consultaBuscada);

                ctx.SaveChanges();

                return true;
            }
            return false;
        }

        public void Deletar(int idConsulta)
        {
            ctx.Consulta.Remove(BuscarPorId(idConsulta));
        }

        public List<Consulta> ListarTodos()
        {
            return ctx.Consulta
                .Select(c => new Consulta()
                {
                    IdConsulta = c.IdConsulta,
                    DataConsulta = c.DataConsulta,
                    Descricao = c.Descricao,
                    IdMedicoNavigation = new Medico()
                    {
                        IdMedico = c.IdMedicoNavigation.IdMedico,
                        IdUsuario = c.IdMedicoNavigation.IdUsuario,
                        Crm = c.IdMedicoNavigation.Crm,
                        NomeMedico = c.IdMedicoNavigation.NomeMedico,
                        IdClinicaNavigation = new Clinica()
                        {
                            NomeFantasia = c.IdMedicoNavigation.IdClinicaNavigation.NomeFantasia,
                            Cnpj = c.IdMedicoNavigation.IdClinicaNavigation.Cnpj,
                            RazaoSocial = c.IdMedicoNavigation.IdClinicaNavigation.RazaoSocial,
                            Endereco = c.IdMedicoNavigation.IdClinicaNavigation.Endereco,
                            Telefone = c.IdMedicoNavigation.IdClinicaNavigation.Telefone,
                            Email = c.IdMedicoNavigation.IdClinicaNavigation.Email,
                        },
                        IdEspecialidadeNavigation = new Especialidade()
                        {
                            NomeEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.NomeEspecialidade
                        },
                        IdUsuarioNavigation = new Usuario()
                        {
                            NomeUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.NomeUsuario,
                            Email = c.IdMedicoNavigation.IdUsuarioNavigation.Email
                        }
                    },
                    IdPacienteNavigation = new Paciente()
                    {
                        IdPaciente = c.IdPacienteNavigation.IdPaciente,
                        DataNascimento = c.IdPacienteNavigation.DataNascimento,
                        NomePaciente = c.IdPacienteNavigation.NomePaciente,
                        Telefone = c.IdPacienteNavigation.Telefone,
                        Rg = c.IdPacienteNavigation.Rg,
                        Cpf = c.IdPacienteNavigation.Cpf,
                        Endereco = c.IdPacienteNavigation.Endereco,
                        IdUsuarioNavigation = new Usuario()
                        {
                            NomeUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.NomeUsuario,
                            Email = c.IdMedicoNavigation.IdUsuarioNavigation.Email
                        }
                    },
                    IdSituacaoNavigation = new Situacao()
                    {
                        IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                        NomeSituacao = c.IdSituacaoNavigation.NomeSituacao
                    }
                })
                .ToList();
        }

        public List<Consulta> VerMinhas(int idUsuario)
        {
            return ctx.Consulta
                .Select(c => new Consulta()
                {
                    IdConsulta = c.IdConsulta,
                    DataConsulta = c.DataConsulta,
                    Descricao = c.Descricao,
                    IdMedicoNavigation = new Medico()
                    {
                        IdMedico = c.IdMedicoNavigation.IdMedico,
                        IdUsuario = c.IdMedicoNavigation.IdUsuario,
                        Crm = c.IdMedicoNavigation.Crm,
                        NomeMedico = c.IdMedicoNavigation.NomeMedico,
                        IdClinicaNavigation = new Clinica()
                        {
                            NomeFantasia = c.IdMedicoNavigation.IdClinicaNavigation.NomeFantasia,
                            Cnpj = c.IdMedicoNavigation.IdClinicaNavigation.Cnpj,
                            RazaoSocial = c.IdMedicoNavigation.IdClinicaNavigation.RazaoSocial,
                            Endereco = c.IdMedicoNavigation.IdClinicaNavigation.Endereco,
                            Telefone = c.IdMedicoNavigation.IdClinicaNavigation.Telefone,
                            Email = c.IdMedicoNavigation.IdClinicaNavigation.Email,
                        },
                        IdEspecialidadeNavigation = new Especialidade()
                        {
                            NomeEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.NomeEspecialidade
                        },
                        IdUsuarioNavigation = new Usuario()
                        {
                            NomeUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.NomeUsuario,
                            Email = c.IdMedicoNavigation.IdUsuarioNavigation.Email
                        }
                    },
                    IdPacienteNavigation = new Paciente()
                    {
                        IdPaciente = c.IdPacienteNavigation.IdPaciente,
                        IdUsuario = c.IdPacienteNavigation.IdUsuario,
                        DataNascimento = c.IdPacienteNavigation.DataNascimento,
                        NomePaciente = c.IdPacienteNavigation.NomePaciente,
                        Telefone = c.IdPacienteNavigation.Telefone,
                        Rg = c.IdPacienteNavigation.Rg,
                        Cpf = c.IdPacienteNavigation.Cpf,
                        Endereco = c.IdPacienteNavigation.Endereco,
                        IdUsuarioNavigation = new Usuario()
                        {
                            NomeUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.NomeUsuario,
                            Email = c.IdMedicoNavigation.IdUsuarioNavigation.Email
                        }
                    },
                    IdSituacaoNavigation = new Situacao()
                    {
                        IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                        NomeSituacao = c.IdSituacaoNavigation.NomeSituacao
                    }
                })
                .Where(p => p.IdMedicoNavigation.IdUsuario == idUsuario || p.IdPacienteNavigation.IdUsuario == idUsuario).ToList();
        }
    }
}
