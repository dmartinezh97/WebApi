using Microsoft.AspNetCore.Http;
using System;

namespace Web.Models.Evento
{
    public class EventoParams
    {
        public long id_negocio { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public IFormFile img_cabecera { get; set; }
    }
}
