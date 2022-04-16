using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace Web.Extens
{
    public static class Utils
    {
        public static long ObtenerIdentificador(this IIdentity identity)
        {
            var claimIdentity = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.NameIdentifier);
            if (claimIdentity != null)
            {
                return long.Parse(claimIdentity.Value);
            }
            else return 0;
        }

        public static string GetJWT(string jwtissure, string jwtkey, List<Claim> claims)
        {
            // Leemos el secret_key desde nuestro appseting
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtkey));

            // Creamos unas credenciales
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // expires: DateTime.Now.AddMinutes(30),
            DateTime expiration = DateTime.UtcNow.AddDays(30);

            JwtSecurityToken token = new JwtSecurityToken(
              jwtissure,
              expires: expiration,
              signingCredentials: creds,
              claims: claims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string GetSHA256(this string input)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(input));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public static bool IsValidEmail(this string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }



    }
}
