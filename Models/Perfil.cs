using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAnnotationsExtensions;
using Identidad.Models.Recursos;

namespace Identidad.Models
{
    public class Perfil
    {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(128), Display(Name = "Nombre(s)", Prompt = "Nombre(s)")]
        public string nombre { get; set; }
        [Required, MaxLength(128), Display(Name = "Apellido", Prompt = "Apellido")]
        public string apellido { get; set; }
        [NotMapped]
        [Display(Name = "Nombre")]

        public string NombreCompleto  {
            get { return apellido + " " + nombre;
                }
        }
        public string NombreTorneo
        {
            get
            {
                return apellido + " " + nombre.Substring(0,1);
            }
        }
        [Display(Name = "Tipo Documento")]
        [ForeignKey("TipoDocumento")]
        public int tDocID { get; set; }
        public TipoDocumento tipoDeDocumento { get; set; }
       
        [Required,  Display(Name = "Numero Documento", Prompt = "Numero")]
        public int numeroDocumento { get; set; }

        
        [Required, MaxLength(64), Display(Name = "Calle", Prompt = "Calle del domicilio")]
        public string calle { get; set; }
        [Required, Display(Name = "Altura", Prompt = "Numero del domicilio")]
        public int altura { get; set; }
        [Required, MaxLength(64), Display(Name = "Ciudad", Prompt = "Ciudad del domicilio")]
        public string ciudad { get; set; }
        [Required,  Display(Name = "Provincia", Prompt = "Provincia del domicilio")]
        [ForeignKey("provincia")]
        public int provinciaID { get; set; }
        public Provincia Provincia { get; set; }
        
        [Email,Required, Display(Name = "Email", Prompt = "Direccion de email")]
        public string Email { get; set; }      
        [MaxLength(16), Display(Name = "Telefono", Prompt = "Telefono Fijo")]
        public string telefono { get; set; }
        [MaxLength(16), Display(Name = "Celular", Prompt = "Celular")]
        public string celular { get; set; }
        [Display(Name = "Club")]
        [ForeignKey("Club")]
        public int clubID { get; set; }
        public Club club { get; set; }
        [Display(Name = "Foto")]
        public byte[] foto { get; set; }
        [MaxLength(512), Display(Name = "Foto", Prompt = "Nombre Archivo Foto")]
        public string fotoPath { get; set; }
        [MaxLength(512), Display(Name = "User ID")]
        public string UserID { get; set; }
        public string Documento()
        {
            {
                return tipoDeDocumento.Abreviacion + " " + numeroDocumento;
            }
        }

        public List<Inscripcion> Inscriptos { get; set; }
        public List<Anotacion> Anotaciones { get; set; }

    }
}
