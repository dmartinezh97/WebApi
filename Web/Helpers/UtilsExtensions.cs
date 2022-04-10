using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Web.Helpers {
    public static class UtilsExtensions {
        public static long ObtenerIdentificador(this IIdentity identity) {
            var claimIdentity = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.NameIdentifier);
            if (claimIdentity != null) {
                return long.Parse(claimIdentity.Value);
            } else return 0;
        }

        public static string GetSHA256(this string input) {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(input));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
