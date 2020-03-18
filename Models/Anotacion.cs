using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class Anotacion
    {
        [Key]
        public int AnotacionID { get; set; }
        [ForeignKey("Perfil")]
        [Display(Name ="Jugador")]
        public int PerfilRefId { get; set; }
        public Perfil Perfil { get; set; }
        [ForeignKey("Torneo")]
        [Display(Name = "Torneo")]
        public int TorneoRefId { get; set; }
        public Torneo2 Torneo { get; set; }
    }
}
