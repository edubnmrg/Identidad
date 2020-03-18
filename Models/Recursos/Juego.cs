using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models.Recursos
{
    public class Juego
    {
        [Key]
        public int JuegoID { get; set; }
        [MaxLength(64),Display(Name="Juego")]
        public string nombreJuego { get; set; }

        public List<Ranking2> Rankings2 { get; set; }
        public List<Juego> Juegos { get; set; }
    }
}
