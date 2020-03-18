using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class PresidenteFederacion
    {
        [Key]
        public int PresFedID { get; set; }
        [ForeignKey("Federaciones")]
        [Display(Name ="Federacion")]
        public int FedID { get; set; }
        public Federacion Federacion { get; set; }
        [ForeignKey("Perfiles")]
        [Display(Name = "Nombre")]
        public int PerfilID { get; set; }
        public Perfil Perfil { get; set; }

        public static implicit operator List<object>(PresidenteFederacion v)
        {
            throw new NotImplementedException();
        }
    }
}
