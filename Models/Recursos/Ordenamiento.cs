using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models.Recursos
{
    public class Ordenamiento
    {
        [Key]
        public int OrdenID { get; set; }
        [Required, Display(Name = "Jugadores")]
        public int Jugadores { get; set; }
        [Required, Display(Name = "P. Nro.")]
        public int Partidoumero { get; set; }
        [Required, Display(Name = "Jugador 1")]
        public int Jugador1 { get; set; }
        [Required, Display(Name = "Jugador 2")]
        public int Jugador2 { get; set; }
    }
}
