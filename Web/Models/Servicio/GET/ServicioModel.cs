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
            idservicio = servicio.IdServicio;
            nombre = servicio.Nombre;
            descripcion = servicio.Descripcion;
            precio = servicio.Precio;
            precio_en_puerta = servicio.PrecioEnPuerta;
            visibilidad = servicio.Visibilidad;
            cantidad = servicio.Cantidad;
            fecha_inicio_venta = servicio.FechaInicioVenta.ToString("yyyy-MM-ddTHH:mm");
            fecha_fin_venta = servicio.FechaFinVenta.ToString("yyyy-MM-ddTHH:mm");
            //idestadoservicio = servicio.EstadoServicio;
            cantidad_max_pp = servicio.CantidadMaximaPorPersona;
        }
    }
}
