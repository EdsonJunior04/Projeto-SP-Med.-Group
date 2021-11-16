using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SpMedGroup_webAPI.Domains
{
    public partial class Consulta
    {
        public long IdConsulta { get; set; }
        public long? IdPaciente { get; set; }
        public long? IdMedico { get; set; }
        public byte? IdSituacao { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
