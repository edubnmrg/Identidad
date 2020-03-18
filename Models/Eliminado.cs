using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class Eliminado
    {
        [Key]
        public int ElininadoID { get; set; }
        [ForeignKey("Torneo2"), Display(Name = "Torneo")]
        public int TorneoID { get; set; }
        public Torneo2 Torneo { get; set; }
        [ForeignKey("Perfils")]
        public int PerfilID { get; set; }
        public Perfil Perfil { get; set; }
        [Display(Name = "Puesto")]
        public int Puesto { get; set; }
        [Display(Name = "Promedio"), DisplayFormat(DataFormatString = "{0: 0.####}")]
        public float Promedio { get; set; }
    }
}
