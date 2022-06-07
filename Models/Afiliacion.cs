using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identidad.Models
{
    public class Afiliacion
    {
        [Key]
        [Display(Name = "Id")]
        public int AfiliacionId {get;set;}
        //[ForeignKey("perfil")]
        [Required,Display(Name = "Jugador")]
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
        [Required, DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        public System.DateTime Fecha {get; set; }
        [Required, Display(Name = "Año")]
        public int Año { get; set; }
        [Required, Display(Name = "Importe"), Column(TypeName = "decimal(16 ,0)"), DisplayFormat(DataFormatString = "{0:$ 0}")]
        public decimal Importe { get; set; }
        //[ForeignKey("autorizo")]
        [Required,Display(Name = "Autorizo")]
        public int AutId { get; set; }
        [InverseProperty("Afiliaciones")]
        public Perfil Autorizo { get; set; }




    }
}
