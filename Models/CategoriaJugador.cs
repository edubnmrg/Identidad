using Identidad.Models.Recursos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class CategoriaJugador
    {
        [Key]
        public int CategoriaJugadorID { get; set; }
        [ForeignKey("Perfil")]
        public int PerfilFK { get; set; }
        public Perfil Perfil { get; set; }
        [ForeignKey("Juego")]
        public int JuegoFK { get; set; }
        public Juego Juego { get; set; }
        [ForeignKey("Categoria")]
        public int CategoriaFK { get; set; }
        public Categoria Categoria { get; set; }
    }
}
