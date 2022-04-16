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
using Web.Models.Auth.POST;
using Web.Servicios.Interfaces;
using Entidades.Usuarios;
using Web.Helpers;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("Todos")]
    public class AuthController : ControllerBase
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;
        private readonly IUsuarioService _usuarioService;
        
        public AuthController(Context context, IConfiguration configuration, IUsuarioService usuarioService) {
            _context = context;
            _configuration = configuration;
            _usuarioService = usuarioService;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(USUARIOS))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login(LoginParams model) {

            var usuario = _usuarioService.Login(model.username, model.password);
            if (usuario == null) return NotFound("Usuario o contraseña incorrecta");

            return await Task.FromResult(Ok(usuario));
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SignUp(SignUpParams model)
        {
            var usuario = _usuarioService.SignUp(model.nombre, model.apellidos, model.usuario, model.email, model.password, model.confirmPassword);
            if (usuario == null) return NotFound("No se ha podido crear la cuenta");

            //TODO: Envíar correo de confirmación
            

            return await Task.FromResult(Ok("Cuenta creada correctamente"));
        }
    }
}