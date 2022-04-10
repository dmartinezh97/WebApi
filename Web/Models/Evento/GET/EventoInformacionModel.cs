using System;
using System.Collections.Generic;
using System.Linq;
using Web.Models.Servicio;

namespace Web.Models.Evento.GET
{
    public class EventoInformacionModel
    {
        public long idevento { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public int estado { get; set; }
        public string img_cabecera { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public int maximo_ventas { get; set; }
        public IEnumerable<ServicioModel> servicios { get; set; }

    }
}
