using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades.Negocios {
    public class NEGOCIOS {
        [Key]
        public long IdNegocio { get; set; }
        public string Slug { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Logo { get; set; }
        public string ImgCabecera { get; set; }
        public string Ubicacion { get; set; }
        //public long IdTipoNegocio { get; set; }
    }
}
