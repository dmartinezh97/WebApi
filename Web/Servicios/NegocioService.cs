using Datos;
using System.Linq;
using Web.Servicios.Interfaces;

namespace Web.Servicios
{
    public class NegocioService : INegocioService
    {
        private readonly Context _context;

        public NegocioService(Context context)
        {
            _context = context;
        }
        
        public bool TengoPermisos(long id_negocio, long id_usuario)
        {
            return _context.NegocioUsuario.Where(x => x.ID_NEGOCIO == id_negocio && x.ID_USUARIO == id_usuario).Count() > 0;
        }

        public bool SlugValido(long id_negocio, string slug)
        {
            return _context.Negocio.Where(x => x.ID_NEGOCIO != id_negocio && x.SLUG == slug).Count() == 0;
        }
    }
}
