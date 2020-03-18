using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models.Recursos
{
    public class TipoDocumento
    {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(32), Display(Name = "Tipo de Documento")]
        public string tipoDeDocumento { get; set; }
        [Required, MaxLength(3), Display(Name = "Abreviacion")]
        public string Abreviacion { get; set; }
    }
}
