using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models.Recursos
{
    public class SistemaTorneo
    {
        [Key]
        public int sisTorID { get; set; }
        [Required, MaxLength(64), Display(Name="Sistema Torneo")]
        public string sisTor { get; set; }
        [Required, Display(Name = "Cantidad de Sets")]
        public int CantSets { get; set; }
        [Required, Display(Name = "Puntos")]
        public int Puntos { get; set; }

        //public List<Torneo2> Torneos { get; set; }

    }
}
