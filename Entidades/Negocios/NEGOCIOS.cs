using Entidades.TipoNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades.Negocios {
    public class NEGOCIOS {
        [Key]
        public long ID_NEGOCIO { get; set; }
        public string SLUG { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public string URL_LOGO { get; set; }
        public string URL_IMG_CABECERA { get; set; }
        public long ID_TIPO_NEGOCIO { get; set; }
        public string UBICACION { get; set; }

        [ForeignKey("ID_TIPO_NEGOCIO")]
        public TIPO_NEGOCIO TIPO_NEGOCIO { get; set; }
    }
}
