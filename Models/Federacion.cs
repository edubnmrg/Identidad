using DataAnnotationsExtensions;
using Identidad.Models.Recursos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.Models
{
    public class Federacion
    {
        [Key]
        public int FederacionID { get; set; }
        [Required, MaxLength(128), Display(Name = "Nombre", Prompt = "Nombre de la Federacion")]
        public string nombre { get; set; }
        [Required, MaxLength(16), Display(Name = "Sigla", Prompt = "Sigla de la Federacion")]
        public string sigla { get; set; }
        [Required, MaxLength(64), Display(Name = "Calle", Prompt = "Calle del domicilio")]
        public string calle { get; set; }
        [Required, Display(Name = "Altura", Prompt = "Numero del domicilio")]
        public int altura { get; set; }
        [Required, MaxLength(64), Display(Name = "Ciudad", Prompt = "Ciudad del domicilio")]
        public string ciudad { get; set; }
        [Display(Name = "Provincia", Prompt = "Provincia del domicilio")]
        //public string provincia { get; set; }
        [ForeignKey("provincia")]
        public int provinciaID { get; set; }
        public Provincia Provincia { get; set; }
        [Email]
        [Required, Display(Name = "Email", Prompt = "Direccion de email")]
        public string fedEmail { get; set; }

        [MaxLength(256), Display(Name = "Url", Prompt = "Direccion del sitio web")]
        public string FedUrl { get; set; }
        [MaxLength(16), Display(Name = "Telefono", Prompt = "Telefono de la Federacion")]
        public string telefono { get; set; }
        public int PresFedID { get; set; }
        public List<ApoderadoFederacion> ApoderadosFederacion { get; set; }
        public List<Club> clubes { get; set; }

    }
}
