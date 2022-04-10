using System.Linq;
using Web.Models.Servicio;

namespace Web.Servicios.Interfaces
{
    public interface IServicioService
    {
        public IQueryable<ServicioModel> GetServiciosNegocio(long id_evento);
        public void NuevoServicio(long id_evento);
        public void ActualizarServicio(ServicioModel servicioDTO);
    }
}
