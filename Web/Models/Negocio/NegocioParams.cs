using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Negocio {
    public class NegocioParams {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public long tipo_negocio { get; set; }
        public string ubicacion { get; set; }
        //public IFormFile logo { get; set; }
        //public IFormFile img_cabecera { get; set; }
    }
}
