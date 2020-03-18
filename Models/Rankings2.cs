using Identidad.Models.Recursos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class Ranking2 { 
    [Key]
    [Display(Name = "RankingID")]
    public int RankingID { get; set; }
    [Display(Name = "Jugador")]
    [ForeignKey("Ranking")]
    public int PerfilID { get; set; }
    [Required, Display(Name = "Categoria")]
    public Perfil Perfil { get; set; }
    [ForeignKey("Categoria")]
    public int CategoriaID { get; set; }
    public Categoria Categoria { get; set; }
    [ForeignKey("Juego")]
    public int JuegoID { get; set; }
    public Juego Juego { get; set; }

    [Required, Display(Name = "Fecha"), DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]

    public DateTime Fecha { get; set; }
    [Required, Display(Name = "Puntos")]

    public int Puntos { get; set; }

}
}
