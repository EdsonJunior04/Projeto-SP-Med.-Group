using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webAPI.ViewModels
{
    public class DescricaoViewModel
    {
        [Required(ErrorMessage = "É necessario informar a nova descrição")]
        [MaxLength(300, ErrorMessage = "A descrição da consulta deve conter no máximo 300 caracteres")]
        public string Descricao { get; set; }
    }
}
