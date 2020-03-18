using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models.Recursos
{
    public class Etapa
    {
        public int EtapaId { get; set; }
        [Required, Display(Name="Etapa")]
        public string NombreEtapa { get; set; }
    }
}
