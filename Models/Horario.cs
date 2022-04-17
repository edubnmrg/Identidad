using System.ComponentModel.DataAnnotations;

namespace Identidad.Models
{
    public class Horario
    {
        [Key]
        public int HorarioId { get; set; } 
        [Required]
        [Display(Name = "Horario"), MaxLength(16)]
        public string horario { get; set; }
    }
}
