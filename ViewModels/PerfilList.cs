using Identidad.Models;
using System.Collections.Generic;

namespace Identidad.ViewModels
{
    public class PerfilList
    {
        public List<Perfil> Perfiles { get; set; }
        public int JuegoDeseado { get; set; }
        public int CategoriaDeseada { get; set; }
        public int ClubDeseado { get; set; }
        public int CiudadDeseada { get; set; }

    }
}
