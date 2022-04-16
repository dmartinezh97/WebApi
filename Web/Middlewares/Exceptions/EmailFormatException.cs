using System;

namespace Web.Middlewares.Exceptions
{
    public class EmailFormatException : Exception
    {
        public EmailFormatException() : base("El formato del correo electrónico no es válido") { }
        public EmailFormatException(string message) : base(message) { }        
    }
}
