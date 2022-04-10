using System;

namespace Web.Models.Evento
{
    public class MisEventosResultModel
    {
        public long idevento { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string img_cabecera { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }
}
