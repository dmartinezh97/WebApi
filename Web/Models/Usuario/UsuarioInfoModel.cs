using Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Usuario {
    public class UsuarioInfoModel {
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string fecha_nacimiento { get; set; }
        public UsuarioInfoModel() { }
        public UsuarioInfoModel(USUARIOS usuario) {
            nombre = usuario.NOMBRE;
            apellidos = usuario.APELLIDOS;
            email = usuario.EMAIL;
            telefono = usuario.TELEFONO;
            if (usuario.FECHA_NACIMIENTO.HasValue) {
                fecha_nacimiento = usuario.FECHA_NACIMIENTO.Value.ToString("yyyy-MM-dd");
            }
        }
    }
}
