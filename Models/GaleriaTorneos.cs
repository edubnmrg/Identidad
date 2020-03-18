using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class GaleriaTorneos
    {
        [Key]
        public int GaleriaTorneosId { get; set; }
        [Required, MaxLength(128), Display(Name = "Foto")]
        public string FotoPath { get; set; }
        [ForeignKey("Torneo"), Display(Name = "Torneo")]
        public int TorneoId { get; set; }
        public Torneo2 Torneo { get; set; }
        [Required, Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }
        [Display(Name = "Nota")]
        public string Nota { get; set; }

    }
}
