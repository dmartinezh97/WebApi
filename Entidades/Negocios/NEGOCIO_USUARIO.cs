using Entidades.Negocios;
using Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades.Negocios {
    public class NEGOCIO_USUARIO {
        [Key]
        public long ID_NEGOCIO_USUARIO { get; set; }
        public long ID_USUARIO { get; set; }
        public long ID_NEGOCIO { get; set; }

        [ForeignKey("ID_USUARIO")]
        public USUARIOS USUARIOS { get; set; }
        [ForeignKey("ID_NEGOCIO")]
        public NEGOCIOS NEGOCIOS { get; set; }
    }
}
