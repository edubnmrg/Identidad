using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class ZonaJugador
    {
        [Key]
        public int ZonaJugadorID { get; set; }
        [ForeignKey("Zona")]
        public int ZonaID { get; set; }
        public Zone Zone { get;  set; }
        public int posicion { get; set; }
        [ForeignKey("Perfil")]
        public int PerfilID { get; set; }
        public Perfil Perfil { get; set; }
        
        public ZonaJugador(int zId, int pos, int per) 
        {
            ZonaID = zId;
            posicion = pos;
            PerfilID = per;
        }

        public ZonaJugador() { }
    }
}
