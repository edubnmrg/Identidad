using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class Modalidad
    {
        [Key]
        public int modalidadID { get; set; }
        [Required, MaxLength(128)]
        public string modalidad { get; set; }
    }
}

