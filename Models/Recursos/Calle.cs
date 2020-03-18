using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Identidad.Models.Recursos;

namespace Identidad.Models
{
    public class Calle
    {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(128), Display(Name = "Nombre ")]
        public string nombre { get; set; }
      
      
    }
}
