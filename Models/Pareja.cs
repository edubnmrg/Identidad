using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class Pareja
    {
        [Key]
        public int ParejaID { get; set; }
        [ForeignKey("Perfiles")]
        public int Jugador1 { get; set; }
        public Perfil Perfil1 { get; set; }
        [ForeignKey("Perfiles")]
        public int Jugador2 { get; set; }
        public Perfil Perfil2 { get; set; }
        [NotMapped]
        public string NombrePareja {get
            {
                return Perfil1.apellido + "-" + Perfil2.apellido;
            }
        }

    }
}
