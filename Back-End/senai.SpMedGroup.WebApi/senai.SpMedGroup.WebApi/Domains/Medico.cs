using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.SpMedGroup.WebApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public long IdMedico { get; set; }
        public long? IdUsuario { get; set; }
        public short? IdClinica { get; set; }
        public byte? IdEspecialidade { get; set; }
        public string NomeMedico { get; set; }
        [Required(ErrorMessage = "Por favor, insira seu nome!")]
        public string Crm { get; set; }
        [Required(ErrorMessage = "Por favor, insira seu CRM!")]

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
