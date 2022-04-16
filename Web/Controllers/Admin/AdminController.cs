using Datos;
using Entidades.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Web.Extens;
using Web.Helpers;
using Web.Models.Auth.POST;
using Web.Servicios.Interfaces;

namespace Web.Controllers.Admin
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize(Roles = Role.Admin)]
    public class AdminController : ControllerBase
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;
        private readonly IUsuarioService _usuarioService;

        public AdminController(Context context, IConfiguration configuration, IUsuarioService usuarioService)
        {
            _context = context;
            _configuration = configuration;
            _usuarioService = usuarioService;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(USUARIOS))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login(LoginParams model)
        {
            var usuario = _usuarioService.Login(model.username, model.password);
            if (usuario == null) return NotFound("Usuario o contraseña incorrecta");
            if (usuario.Rol != Role.Admin) return NotFound("No tiene permisos para acceder a esta sección");

            return await Task.FromResult(Ok(usuario));
        }
    }
}
