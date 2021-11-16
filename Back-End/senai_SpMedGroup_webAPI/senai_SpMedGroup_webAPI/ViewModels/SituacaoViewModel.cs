using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedGroup_webAPI.ViewModels
{
    public class SituacaoViewModel
    {
        [Required(ErrorMessage = "É necessario informar a situação da consulta")]
        public byte? IdSituacao { get; set; }
    }
}
