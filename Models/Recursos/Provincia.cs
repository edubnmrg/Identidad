using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models.Recursos
{
    public class Provincia
    {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(128)]       
        public string nombre { get; set; }

        public List<Ciudad> ciudades { get; set; }
    }
}
