using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class Inscripcion
    {
        [Key]
        public int InscripcionID { get; set; }
        [ForeignKey("Perfil")]
        public int PerfilFK { get; set; }
        public Perfil Perfil { get; set; }
        [ForeignKey("Torneo")]
        public int TorneoFK { get; set; }
        public Torneo Torneo { get; set; }
    }
}
