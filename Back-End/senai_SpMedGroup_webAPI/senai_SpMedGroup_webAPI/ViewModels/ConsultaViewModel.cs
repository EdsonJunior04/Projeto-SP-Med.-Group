using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webAPI.ViewModels
{
    public class ConsultaViewModel
    {
        [Required(ErrorMessage = "É necessario informar o paciente")]
        public int? IdPaciente { get; set; }

        [Required(ErrorMessage = "É necessario informar o médico")]
        public short? IdMedico { get; set; }

        [Required(ErrorMessage = "É necessario informar a data da consulta")]
        public DateTime DataConsulta { get; set; }
    }
}
