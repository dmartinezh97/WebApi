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
            return _context.NegocioUsuario.Where(x => x.IdNegocio == id_negocio && x.IdUsuario == id_usuario).Count() > 0;
        }

        public bool SlugValido(long id_negocio, string slug)
        {
            return _context.Negocio.Where(x => x.IdNegocio != id_negocio && x.Slug == slug).Count() == 0;
        }
    }
}
