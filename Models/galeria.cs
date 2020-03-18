using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class Galeria
    {
        [Key]
        public int GaleriaId { get; set; }
        [Required, MaxLength(128), Display(Name = "Foto")]
        public string FotoPath { get; set; }
        [Required, Display(Name = "Fecha"), DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime Fecha { get; set; }
        [ Display(Name = "Nota")]
        public string Nota { get; set; }

       
    }
}
