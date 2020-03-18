using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }
        [ForeignKey("Partidos")]
        public int PartidoId { get; set; }
        public Partido Partido { get; set; }
        [Required, Display(Name = "Set")]
        public int NumeroSet { get; set; }
        [Required, Display(Name = "Jugador1"), DisplayFormat(DataFormatString ="{0:#}")]
        public int Score1 { get; set; }
        [Required, Display(Name = "Jugador2"), DisplayFormat(DataFormatString = "{0:#}")]
        public int Score2 { get; set; }
    }
}
