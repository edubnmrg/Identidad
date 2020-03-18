using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class ApoderadoClub
    {
        [Key]
        public int ApoClubID { get; set; }
        [ForeignKey("Clubes")]
        [Display(Name = "Club")]
        public int ClubID { get; set; }
        public Club Club { get; set; }
        [ForeignKey("Perfiles")]
        [Display(Name = "Nombre")]
        public int PerfilID { get; set; }
        public Perfil Perfil { get; set; }
    }
}
