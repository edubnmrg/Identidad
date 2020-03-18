using Identidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.ViewModels
{
    public class CrucesViewModel
    {
        public Torneo2 Torneo { get; set; }
        public List<Clasificado> Clasificados { get; set; }
        public List<Partido> Partidos { get; set; }
    }
}
