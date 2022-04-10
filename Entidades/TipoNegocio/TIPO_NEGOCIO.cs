using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades.TipoNegocio {
    public class TIPO_NEGOCIO {
        [Key]
        public long ID_TIPO_NEGOCIO { get; set; }
        public string NOMBRE { get; set; }
    }
}
