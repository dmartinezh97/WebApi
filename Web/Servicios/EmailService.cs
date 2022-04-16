using Datos;
using System;
using Web.Middlewares.Exceptions;
using Web.Servicios.Interfaces;

namespace Web.Servicios
{
    public class EmailService : IEmailService
    {
        private readonly Context _context;
        
        public EmailService(Context context)
        {
            _context = context;
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                //TODO: Comprobar en un listado si está dentro de los dominios permitidos
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;            
            }
            catch (FormatException)
            {
                throw new EmailFormatException();
            }
        }
    }
}
