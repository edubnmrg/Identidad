using Identidad.Models;
using Identidad.Models.Recursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.ViewModels
{
    public class Rankings2VM
    {
        public List<Categoria> Categorias { get; set; }

        public List<Ranking2> Rankings { get; set; }
        public int CategoriaActiva { get; set; }
    }
}
