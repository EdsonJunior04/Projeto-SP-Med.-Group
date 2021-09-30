using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.SpMedGroup.WebApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public long IdUsuario { get; set; }
        public byte? IdTipoU { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Por favor, insira um email!")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Por favor, insira uma senha segura!")]
        public virtual Tipousuario IdTipoUNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
        public object IdTipoUsuarioNavigation { get; internal set; }
    }
}
