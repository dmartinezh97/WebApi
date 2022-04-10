using Entidades.Servicios;
using System;

namespace Web.Models.Servicio
{
    public class ServicioModel
    {
        public long idservicio { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public double precio_en_puerta { get; set; }
        public bool visibilidad { get; set; }
        public int cantidad { get; set; }
        public string fecha_inicio_venta { get; set; }
        public string fecha_fin_venta { get; set; }
        public long idestadoservicio { get; set; }
        public int cantidad_max_pp { get; set; }
        public ServicioModel() { }
        public ServicioModel(SERVICIOS servicio) {
            idservicio = servicio.ID_SERVICIO;
            nombre = servicio.NOMBRE;
            descripcion = servicio.DESCRIPCION;
            precio = servicio.PRECIO;
            precio_en_puerta = servicio.PRECIO_EN_PUERTA;
            visibilidad = servicio.VISIBILIDAD;
            cantidad = servicio.CANTIDAD;
            fecha_inicio_venta = servicio.FECHA_INICIO_VENTA.ToString("yyyy-MM-ddTHH:mm");
            fecha_fin_venta = servicio.FECHA_FIN_VENTA.ToString("yyyy-MM-ddTHH:mm");
            idestadoservicio = servicio.ID_ESTADO_SERVICIO;
            cantidad_max_pp = servicio.CANTIDAD_MAX_PP;
        }
    }
}
