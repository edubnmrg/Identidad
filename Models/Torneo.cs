using Identidad.Models.Recursos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class Torneo
    {
        [Key]
        public int TorneoID { get; set; }
        [Required, MaxLength(128), Display(Name = "Torneo")]
        public string NombreTorneo { get; set; }
        [ForeignKey("Club"), Display(Name = "Club Organizador")]
        public int ClubFK { get; set; }
        public Club Club { get; set; }
       
        [ForeignKey("CategoriaTorneo"), Display(Name = "Clase Torneo")]
        public int CatTorFK { get; set; }
        public CategoriaTorneo CatTor { get; set; }
        [ForeignKey("CantidadJugadores"), Display(Name = "Cantidad Jugadores")]
        public int CanJugFK { get; set; }
        public CantidadJugadores CanJug { get; set; }
        [ForeignKey("Categoria"), Display(Name = "Categoria")]
        public int CatFK { get; set; }
        public Categoria Cat { get; set; }
        [ForeignKey("SistemaTorneo"), Display(Name = "Sistema")]
        public int SisTorFK { get; set; }
        public SistemaTorneo SisTor { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}"), Display(Name = "Desde")]
        public DateTime Desde { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}"), Display(Name = "Hasta")]
        public DateTime Hasta { get; set; }
        [Required, Column(TypeName="decimal(16 ,0)"),DisplayFormat(DataFormatString = "{0:$ 0}")]
        [ Display(Name = "Valor Inscripcion")]
        public Decimal ValorInscripcion { get; set; }
        [MaxLength(512), Display(Name = "Notas")]
        public string Notas { get; set; }
        public List<Inscripcion> Inscriptos { get; set; }
        public List<Zona> Zonas { get; set; }


    }
}
