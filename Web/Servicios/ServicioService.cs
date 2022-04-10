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
            return _context.Servicios.Where(x => x.ID_EVENTO == id_evento).Select(x => new ServicioModel(x));
        }

        public void NuevoServicio(long id_evento)
        {
            var newServicio = new SERVICIOS();
            newServicio.ID_EVENTO = id_evento;
            newServicio.NOMBRE = "Nuevo servicio";
            newServicio.DESCRIPCION = "Descripción del servicio";
            newServicio.VISIBILIDAD = false;
            newServicio.FECHA_INICIO_VENTA = DateTime.Now.Date;
            newServicio.FECHA_FIN_VENTA = DateTime.Now.Date.AddDays(1);
            newServicio.ID_ESTADO_SERVICIO = (long)EstadoServicioEnum.EnVenta;
            _context.Servicios.Add(newServicio);
        }

        public void ActualizarServicio(ServicioModel servicioDTO)
        {
            //Comprobar si tengo permisos para editar este servicio
            var servicio = _context.Servicios.Find(servicioDTO.idservicio);
            if (servicio == null) throw new ArgumentException("No se encontró el servicio");
            
            servicio.ID_ESTADO_SERVICIO = servicioDTO.idestadoservicio;
            servicio.NOMBRE = servicioDTO.nombre;
            servicio.DESCRIPCION = servicioDTO.descripcion;
            servicio.CANTIDAD = servicioDTO.cantidad;
            servicio.VISIBILIDAD = servicioDTO.visibilidad;
            servicio.PRECIO = servicioDTO.precio;
            servicio.PRECIO_EN_PUERTA = servicioDTO.precio_en_puerta;
            
            var fechaInicioVenta = DateTime.Parse(servicioDTO.fecha_inicio_venta);
            servicio.FECHA_INICIO_VENTA = fechaInicioVenta;
            
            var fechaFinVenta = DateTime.Parse(servicioDTO.fecha_fin_venta);
            if (fechaFinVenta <= fechaInicioVenta) throw new ArgumentException("La fecha de fin de venta no puede ser anterior a la fecha de inicio de venta");
            servicio.FECHA_FIN_VENTA = fechaFinVenta;


            servicio.CANTIDAD_MAX_PP = servicioDTO.cantidad_max_pp;
        }
    }
}
