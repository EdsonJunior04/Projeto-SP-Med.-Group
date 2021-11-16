using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SpMedGroup_webAPI.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consulta>();
        }

        public byte IdSituacao { get; set; }
        public string NomeSituacao { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
