using Identidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.ViewModels
{
    public class Torneo2ViewModel
    {
        public Torneo2 Tor { get; set; }
        public List<List<int>> Partidos { get; set; }
        public int ZonaActiva{get;set;}

        public List<String> apellidos { get; set; }
    }
}
