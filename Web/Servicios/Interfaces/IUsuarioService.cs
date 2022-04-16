using Entidades.Usuarios;

namespace Web.Servicios.Interfaces
{
    public interface IUsuarioService
    {
        public USUARIOS Login(string usuario, string password);
        public USUARIOS SignUp(string nombre, string apellidos, string usuario, string email, string password, string confirmPassword);
    }
}
