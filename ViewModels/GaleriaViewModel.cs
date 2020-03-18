using Identidad.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identidad.ViewModels
{
    public class GaleriaViewModel : Galeria
    {
        public IFormFile Photo {get;set;}
    }
}
