using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models.Recursos
{
    public class Ciudad
    {
        [Key]
        public int CiudadID { get; set; }
        [Required, MaxLength(128), Display(Name = "Nombre ")]
        public string nombre { get; set; }
        [ForeignKey("Provincia"), Display(Name = "Provincia ")]
        public int ProvinciaID { get; set; }
        public Provincia Provincia { get; set; }
    }
}
