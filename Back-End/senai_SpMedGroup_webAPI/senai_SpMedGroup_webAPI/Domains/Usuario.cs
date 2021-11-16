using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SpMedGroup_webAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Fotoperfils = new HashSet<Fotoperfil>();
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public long IdUsuario { get; set; }
        public byte? IdTipoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual Tipousuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Fotoperfil> Fotoperfils { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
