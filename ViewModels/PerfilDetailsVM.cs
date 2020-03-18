using Identidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.ViewModels
{
    public class PerfilDetailsVM
    {
        public Perfil Perfil { get; set; }
        public List<CategoriaJugador> CategoriasJugador { get; set; }
        
        public List<Ranking2> Rankings { get; set; }
    }
}
