using Entidades.Usuarios;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models.Auth {
    public class LoginResultModel {
        public long idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string token { get; set; }

        public LoginResultModel() { }
        public LoginResultModel(USUARIOS usuario) {
            idUsuario = usuario.ID_USUARIO;
            nombre = usuario.NOMBRE;
            apellidos = usuario.APELLIDOS;
            email = usuario.EMAIL;
        }

        public List<Claim> GetClaims() {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, idUsuario.ToString()),
                new Claim(ClaimTypes.Name, nombre),
            };
            return claims;
        }

    }
}
