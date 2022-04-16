using Datos;
using Entidades.Usuarios;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Web.Extens;
using Web.Helpers;
using Web.Servicios.Interfaces;

namespace Web.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly Context _context;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public UsuarioService(Context context, IEmailService emailService, IConfiguration configuration)
        {
            _context = context;
            _emailService = emailService;
            _configuration = configuration;
        }

        public USUARIOS Login(string usuario, string password)
        {
            var user = _context.Usuarios.FirstOrDefault(x => x.Email == usuario && x.Password == password.GetSHA256()).SinPassword();
            if (user == null) return null;
            user.Token = Utils.GetJWT(_configuration["Jwt:Issure"], _configuration["Jwt:Key"], user.GetClaims());
            return user;
        }

        public USUARIOS SignUp(string nombre, string apellidos, string usuario, string email, string password, string confirmPassword)
        {
            if (password != confirmPassword) throw new ArgumentException("Las contraseñas no coinciden");
            if (!_emailService.IsValidEmail(email)) return null;
            if(EmailExists(email)) throw new ArgumentException("Parece que ya estás registrado");

            var user = new USUARIOS
            {
                Nombre = nombre,
                Apellidos = apellidos,
                Usuario = usuario,
                Email = email,
                Password = password.GetSHA256(),
                Rol = Role.User,
            };
            _context.Usuarios.Add(user);
            _context.SaveChanges();
            return user.SinPassword();
        }

        //Function to check if email exists in database
        public bool EmailExists(string email)
        {
            return _context.Usuarios.Any(x => x.Email == email);
        }
    }
}
