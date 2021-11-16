using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SpMedGroup_webAPI.Domains
{
    public partial class Fotoperfil
    {
        public int IdFotoPerfil { get; set; }
        public long? IdUsuario { get; set; }
        public string NomeArquivo { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
