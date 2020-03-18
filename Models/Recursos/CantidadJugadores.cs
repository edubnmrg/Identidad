using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models.Recursos
{
    public class CantidadJugadores
    {
        [Key]
        public int cantJugID { get; set; }
        [Required, Display(Name="Cantidad de Jugadores")]
        public string cantJug { get; set; }

        public List<Torneo2> Torneos { get; set; }

    }
}
