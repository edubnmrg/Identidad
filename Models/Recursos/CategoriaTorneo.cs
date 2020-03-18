using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models.Recursos
{
    public class CategoriaTorneo
    {
        [Key]
        public int catTorneoID { get; set; }
        [Required, MaxLength(64), Display(Name="Categoria Torneo")]
        public string catTorneo { get; set; }
        [Required, MaxLength(8), Display(Name = "Color"), DefaultValue("#fff")]
        public string Color { get; set; } 
        public List<Torneo2> Torneos { get; set; }
    }
}
