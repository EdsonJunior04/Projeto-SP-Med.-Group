using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SpMedGroup_webAPI.Domains
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
        public string Crm { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
