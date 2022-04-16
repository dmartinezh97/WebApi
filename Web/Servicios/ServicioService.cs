using Datos;
using Entidades.Servicios;
using System;
using System.Linq;
using Web.Enums;
using Web.Models.Servicio;
using Web.Servicios.Interfaces;

namespace Web.Servicios
{
    public class ServicioService : IServicioService
    {
        private readonly Context _context;

        public ServicioService(Context context)
        {
            _context = context;
        }
        
        public IQueryable<ServicioModel> GetServiciosNegocio(long id_evento)
        {
            return _context.Servicios.Where(x => x.IdEvento == id_evento).Select(x => new ServicioModel(x));
        }

        public void NuevoServicio(long id_evento)
        {
            var newServicio = new SERVICIOS();
            newServicio.IdEvento = id_evento;
            newServicio.Nombre = "Nuevo servicio";
            newServicio.Descripcion = "Descripción del servicio";
            newServicio.Visibilidad = false;
            newServicio.FechaInicioVenta = DateTime.Now.Date;
            newServicio.FechaFinVenta = DateTime.Now.Date.AddDays(1);
            //newServicio.EstadoServicio = (long)EstadoServicioEnum.EnVenta;
            _context.Servicios.Add(newServicio);
        }

        public void ActualizarServicio(ServicioModel servicioDTO)
        {
            //Comprobar si tengo permisos para editar este servicio
            var servicio = _context.Servicios.Find(servicioDTO.idservicio);
            if (servicio == null) throw new ArgumentException("No se encontró el servicio");
            
            //servicio.EstadoServicio = servicioDTO.idestadoservicio;
            servicio.Nombre = servicioDTO.nombre;
            servicio.Descripcion = servicioDTO.descripcion;
            servicio.Cantidad = servicioDTO.cantidad;
            servicio.Visibilidad = servicioDTO.visibilidad;
            servicio.Precio = servicioDTO.precio;
            servicio.PrecioEnPuerta = servicioDTO.precio_en_puerta;
            
            var fechaInicioVenta = DateTime.Parse(servicioDTO.fecha_inicio_venta);
            servicio.FechaInicioVenta = fechaInicioVenta;
            
            var fechaFinVenta = DateTime.Parse(servicioDTO.fecha_fin_venta);
            if (fechaFinVenta <= fechaInicioVenta) throw new ArgumentException("La fecha de fin de venta no puede ser anterior a la fecha de inicio de venta");
            servicio.FechaFinVenta = fechaFinVenta;


            servicio.CantidadMaximaPorPersona = servicioDTO.cantidad_max_pp;
        }
    }
}
