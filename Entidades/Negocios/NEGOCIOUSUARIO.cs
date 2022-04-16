using Entidades.Negocios;
using Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades.Negocios {
    public class NEGOCIOUSUARIO {
        [Key]
        public long IdNegocioUsuario { get; set; }
        public long IdUsuario { get; set; }
        public long IdNegocio { get; set; }

        [ForeignKey("IdUsuario")]
        public USUARIOS USUARIOS { get; set; }
        [ForeignKey("IdNegocio")]
        public NEGOCIOS NEGOCIOS { get; set; }
    }
}
