using System.ComponentModel.DataAnnotations;

namespace Identidad.Models
{
    public class ZonaManual
    {
        [Key]
        public int ZonaManualId { get; set; }
        [Display(Name = "Numero")]
        public int Numero { get; set; }
        [Display(Name = "Torneo")]
        public int TorneoID { get; set; }
        public Torneo2 Torneo { get; set; }

        [Display(Name = "Jugador 1"), MaxLength(32)]
        public string Jugador1 { get; set; }
        [Display(Name = "Jugador 2"), MaxLength(32)]
        public string Jugador2 { get; set; }
        [Display(Name = "Jugador 3"), MaxLength(32)]
        public string Jugador3 { get; set; }
        [Display(Name = "Jugador 4"), MaxLength(32)]
        public string Jugador4 { get; set; }
        [Display(Name = "Ganador 1"), MaxLength(32)]
        public string Ganador1 { get; set; }
        [Display(Name = "Perdedor 1"), MaxLength(32)]
        public int Perdedor1 { get; set; }
        [Display(Name = "Ganador 2"), MaxLength(32)]
        public int Ganador2 { get; set; }
        [Display(Name = "Perdedor 2"), MaxLength(32)]
        public int Perdedor2 { get; set; }
        [Display(Name = "Ganador Zona"), MaxLength(32)]
        public int GanadorZona { get; set; }
        [Display(Name = "Repechaje 1"), MaxLength(32)]
        public int Repechaje1 { get; set; }
        [Display(Name = "Repechaje 2"), MaxLength(32)]
        public int Repechaje2 { get; set; }
        [Display(Name = "Segundo Zona"), MaxLength(32)]
        public int SegundoZona { get; set; }
    }
}

