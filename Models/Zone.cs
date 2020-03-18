using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class Zone
    {
        [Key]
        public int ZonaID { get; set; }
        [ForeignKey("Torneo")]
        public int TorneoID { get; set; }
        public Torneo2 Torneo { get; set; }
        public int Numero { get; set; }
        public int CantidadJugadores { get; set; }

        public List<ZonaJugador> ZonaJugadores;
        public List<Partido> Partidos;
        public Zone()
        {

        }
        public Zone(int zId, int tId, int n, int c)
        {
            ZonaID = zId;
            TorneoID = tId;
            Numero = n;
            CantidadJugadores = c;
        }
    }
}
