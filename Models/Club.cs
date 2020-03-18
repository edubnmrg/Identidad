using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAnnotationsExtensions;

using System.Linq;
using System.Threading.Tasks;
using Identidad.Models.Recursos;

namespace Identidad.Models
{
    public class Club
    {
        [Key]
        public int ClubID { get; set; }
        [Required, MaxLength(128), Display(Name = "Nombre")]
        public string NombreClub { get; set; }
        [Required, MaxLength(16), Display(Name = "Sigla")]
        public string SiglaClub { get; set; }
        [Required, MaxLength(64), Display(Name = "Calle")]
        public string Calle { get; set; }
        [Required, MaxLength(16), Display(Name = "Altura")]
        public string Altura { get; set; }
        public string Domicilio
        {
            get { return Calle + " " + Altura; }
        }
        [Required, MaxLength(64), Display(Name = "Ciudad")]
        public string Ciudad { get; set; }
        [ForeignKey("provincia")]
        [ Display(Name = "Provincia")]
        public int ProvinciaID { get; set; }
        public Provincia Provincia { get; set; }
        [Email]
        [Required, MaxLength(256), Display(Name = "Email")]
        public string ClubEmail { get; set; }

        [Required, MaxLength(256), Display(Name = "URL")]
        public string ClubUrl { get; set; }
        [MaxLength(16), Display(Name = "Telefono")]
        public string Telefono { get; set; }
        [ForeignKey("Federacion")]
        [Display(Name = "Federacion")]
        public int FederacionID { get; set; }
        public Federacion Federacion { get; set; }
        public int PresidenteID { get; set; }
        
        public int PresClubID { get; set; }
        public PresidenteClub PresidenteClub { get; set; }
        public List<ApoderadoClub> ApoderadosClub  { get; set; }
        public List<Torneo2> Torneos { get; set; }
    }
}
