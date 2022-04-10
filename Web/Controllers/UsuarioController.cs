using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Web.Models.Auth;
using Web.Models.Usuario;
using Web.Helpers;

namespace Web.Controllers
{
    [EnableCors("Todos")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Context _context;
        
        public UsuarioController(IConfiguration configuration, Context context) {
            _configuration = configuration;
            _context = context;
        }

        /// <summary>
        /// Retorna la información del usuario
        /// </summary>
        // GET: api/Usuario/GetInfo
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResultModel))]
        public async Task<IActionResult> GetInfo() {
            long id = User.Identity.ObtenerIdentificador();
            var usuario = _context.Usuarios.Find(id);
            
            UsuarioInfoModel result = new UsuarioInfoModel(usuario);
            
            return await Task.FromResult(Ok(result));
        }

        /// <summary>
        /// Actualiza la información del usuario
        /// </summary>
        // PUT: api/Usuario/GetInfo
        [HttpPut("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateInfo(UsuarioInfoModel modelo) {
            long id = User.Identity.ObtenerIdentificador();
            var usuario = _context.Usuarios.Find(id);

            usuario.NOMBRE = modelo.nombre;
            usuario.APELLIDOS = modelo.apellidos;
            usuario.TELEFONO = modelo.telefono;
            usuario.FECHA_NACIMIENTO = DateTime.Parse(modelo.fecha_nacimiento);

            _context.SaveChanges();


            return await Task.FromResult(Ok());
        }

    }
}