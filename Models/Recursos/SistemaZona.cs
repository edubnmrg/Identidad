using System.ComponentModel.DataAnnotations;

namespace Identidad.Models.Recursos
{
    public class SistemaZona
    {
        [Key]  
        public int SisZonId { get; set; } 
        [Required]
        [StringLength(100), Display(Name = "Sistema")]
        public string Sistema { get; set; }
    }
}
