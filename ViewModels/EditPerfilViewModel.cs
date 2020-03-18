using Identidad.Models;
using Identidad.Models.Recursos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.ViewModels
{
    public class EditPerfilViewModel: Perfil
    {
        [Display(Name = "Foto")]
        public IFormFile Photo { get; set; }
        public List<TipoDocumento> TipoDocumentos { get; set; }
        public List<Provincia> Provincias { get; set; }
        public List<Club> Clubes { get; set; }

        public void ToParent(Perfil p)
        {
            p.ID = this.ID;
            p.nombre = this.nombre;
            p.apellido = this.apellido;
            p.tDocID = this.tDocID;
            p.numeroDocumento = this.numeroDocumento;
            p.calle = this.calle;
            p.altura = this.altura;
            p.ciudad = this.ciudad;
            p.provinciaID = this.provinciaID;
            p.Email = this.Email;
            p.telefono = this.telefono;
            p.celular = this.celular;
            p.clubID = this.clubID;
            p.club = this.club;
            p.foto = this.foto;
            p.fotoPath = this.fotoPath;
            p.UserID = this.UserID;
        }
        public void FromParent(Perfil p)
        { 
            this.ID = p.ID;
            this.nombre = p.nombre;
            this.apellido = p.apellido;
            this.tDocID = p.tDocID;
            this.numeroDocumento = p.numeroDocumento;
            this.calle = p.calle;
            this.altura = p.altura;
            this.ciudad = p.ciudad;
            this.provinciaID = p.provinciaID;
            this.Email = p.Email;
            this.telefono = p.telefono;
            this.celular = p.celular;
            this.clubID = p.clubID;
            this.club = p.club;
            this.foto = p.foto;
            this.fotoPath = p.fotoPath;
            this.UserID = p.UserID;
    }
    }
}
