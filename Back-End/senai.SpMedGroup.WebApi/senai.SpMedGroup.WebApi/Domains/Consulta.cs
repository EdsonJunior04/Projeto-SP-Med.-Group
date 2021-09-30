using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.SpMedGroup.WebApi.Domains
{
    public partial class Consulta
    {
        public long IdConsulta { get; set; }
        public long? IdPaciente { get; set; }
        public long? IdMedico { get; set; }
        public byte? IdSituacao { get; set; }
        public DateTime DataConsulta { get; set; }
        [Required(ErrorMessage = "Por favor, insira a data da consulta!")]
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
