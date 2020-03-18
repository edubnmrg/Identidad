using Identidad.Models.Recursos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class Partido
    {
       

        [Key]
        public int PartidoId { get; set; }
        [ForeignKey("Jugadores")]
        [Required, Display(Name="Jugador1")]
        public int Jugador1Id {get;set;}
        public Perfil Perfil1 { get; set; }
        [ForeignKey("Jugadores")]
        [Required, Display(Name = "Jugador2")]
        public int Jugador2Id { get; set; }
        public Perfil Perfil { get; set; }
        [ForeignKey("Zonas")]
        [Required, Display(Name = "Zona")]
        public int ZonaId { get; set; }
        public Zone Zone { get; set; }
        [ForeignKey("Etapas")]
        [Required, Display(Name = "Etapa")]
        public int EtapaId { get; set; }
        public Etapa Etapa { get; set; }
        public int Ronda { get; set; }
        public int PartidoNumero { get; set; }
        public bool Cerrado { get; set; }
        public int Ganador { get; set; }
        [Required,ForeignKey("Torneos")]
        [Display(Name = "Torneo")]
        public int TorneoID { get; set; }
        public Torneo2 Torneo { get; set; }
        public List<Score> Scores { get; set; }
       

       
    }
}
