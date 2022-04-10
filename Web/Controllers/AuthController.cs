using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Web.Models.Auth;

namespace Web.Controllers
{
    [EnableCors("Todos")]
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Context _context;
        
        public AuthController(IConfiguration configuration, Context context) {
            _configuration = configuration;
            _context = context;
        }

        /// <summary>
        /// Retorna el token necesario para consumir los endpoint
        /// </summary>
        // POST: api/Auth/Login
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResultModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(404)]
        public async Task<IActionResult> Login(LoginParams model) {

            var usuario = _context.Usuarios.Where(x => x.EMAIL.Equals(model.username) && x.PASSWORD.Equals(model.password)).FirstOrDefault();
            if (usuario == null) return NotFound("Usuario o contraseña incorrecta");

            LoginResultModel result = new LoginResultModel(usuario);
            result.token = GetJWT(result.GetClaims());
            //PERSONA persona = _context.Personas.Where(x => x.PERALIAS == model.usuario).First();

            //if (!persona.AT_PASSWORD_PLANTA.Equals(UtilsExtensions.GetSHA256(model.password))) throw new ArgumentException("Contraseña incorrecta");
            //Usuario user = new Usuario(persona);
            //user.token = GenerarToken(persona);

            return await Task.FromResult(Ok(result));
        }

        private string GetJWT(List<Claim> claims) {
            // Leemos el secret_key desde nuestro appseting
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));

            // Creamos unas credenciales
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // expires: DateTime.Now.AddMinutes(30),
            DateTime expiration = DateTime.UtcNow.AddDays(30);

            JwtSecurityToken token = new JwtSecurityToken(
              _configuration["Jwt:Issure"],
              expires: expiration,
              signingCredentials: creds,
              claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}