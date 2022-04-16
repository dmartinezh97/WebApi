using Entidades.Usuarios;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Web.Extens
{
    public static class UsuariosExtensions
    {
        public static IQueryable<USUARIOS> SinPasswords(this IQueryable<USUARIOS> usuarios)
        {
            return usuarios.Select(x => x.SinPassword());
        }
        
        public static USUARIOS SinPassword(this USUARIOS usuario)
        {
            if (usuario == null) return null;
            usuario.Password = null;
            return usuario;
        }

        public static List<Claim> GetClaims(this USUARIOS usuario)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuario.Rol),
            };
            return claims;
        }
    }
}
