using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.SpMedGroup.WebApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public long IdPaciente { get; set; }
        public long? IdUsuario { get; set; }
        public string NomePaciente { get; set; }
        [Required(ErrorMessage = "Por favor, insira seu nome!")]
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        [Required(ErrorMessage = "Por favor, insira sua data de nascimento!")]
        public string Rg { get; set; }
        [Required(ErrorMessage = "Por favor, insira seu RG!")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Por favor, insira seu CPF!")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Por favor, insira seu seu enderço!")]
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
