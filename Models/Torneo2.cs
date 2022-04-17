using Identidad.Models.Recursos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class Torneo2
    {
        [Key]
        public int TorneoID { get; set; }
        [Required, MaxLength(128), Display(Name = "Torneo")]
        public string NombreTorneo { get; set; }
        [ForeignKey("Club"), Display(Name = "Club Organizador")]
        public int ClubRefId { get; set; }
        public Club Club { get; set; }

        [ForeignKey("CategoriaTorneo"), Display(Name = "Clase Torneo")]
        public int CatTorRefId { get; set; }
        public CategoriaTorneo CatTor { get; set; }
        [ForeignKey("CantidadJugadores"), Display(Name = "Cantidad Jugadores")]
        public int CanJugRefId { get; set; }
        public CantidadJugadores CanJug { get; set; }
        public int JuegoID { get; set; }

        [ForeignKey("Categoria"), Display(Name = "Categoria")]
        public int CatRefId { get; set; }
        public Categoria Cat { get; set; }
        [ForeignKey("SistemaTorneo"), Display(Name = "Sistema")]
        public int SisTorRefId { get; set; }
        public SistemaTorneo SisTor { get; set; }
        [ForeignKey("SistemaZona"), Display(Name = "Sistema")]
        public int SisZonRefId { get; set; }
        public SistemaZona SisZon { get; set; }
        //[Required]
        [Display(Name = "Sets")]
        public int Sets { get; set; }
        //[Required]
        [Display(Name = "Puntos")]
        public int Puntos { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}"), Display(Name = "Desde")]
        public DateTime Desde { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}"), Display(Name = "Hasta")]
        public DateTime Hasta { get; set; }
        [Required, Column(TypeName = "decimal(16 ,0)"), DisplayFormat(DataFormatString = "{0:$ 0}")]
        [Display(Name = "Valor Inscripcion")]
        public Decimal ValorInscripcion { get; set; }
        [MaxLength(512), Display(Name = "Notas")]
        public string Notas { get; set; }
        [Display(Name = "I. Cerr")]
        public bool InscripcionCerrada { get; set; }

        [Display(Name = "Z. Cerr")]
        public bool ZonasCerradas { get; set; }
        [Display(Name = "C. Cerr")]
        public bool CrucesCerrados { get; set; }
        [Display(Name = "T. Cerr")]
        public bool TorneoCerrado { get; set; }

        public List<Anotacion> Anotaciones { get; set; }
        public List<Partido> Matches { get; set; }
        public List<Zone> Zones { get; set; }
    }
}
