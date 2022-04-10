using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades.Usuarios {
    public class USUARIOS {
        [Key]
        public long ID_USUARIO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDOS { get; set; }
        public string USUARIO { get; set; }
        public string PASSWORD { get; set; }
        public string TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public DateTime? FECHA_NACIMIENTO { get; set; }
        public long ROL_USUARIO { get; set; }
    }
}
