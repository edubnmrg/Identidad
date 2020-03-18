using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models.Recursos
{
    public class Categoria
    {
        [Key]
        public int categoriaID { get; set; }
        [Required, MaxLength(32), Display(Name = "Categoria")]
        public string categoria { get; set; }
        [Required, MaxLength(8), Display(Name = "Color"), DefaultValue("#fff")]
        public string Color { get; set; }

        public List<Torneo2> Torneos { get; set; }
        public List<Ranking2> Rankings2 { get; set; }
    }
}
