using Datos;
using Entidades.Eventos;
using Entidades.Negocios;
using Entidades.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web.Enums;
using Web.Helpers;
using Web.Models.Evento;
using Web.Models.Evento.GET;
using Web.Models.Negocio;
using Web.Models.Servicio;
using Web.Models.Servicio.PUT;
using Web.Servicios.Interfaces;

namespace Web.Controllers
{
    [EnableCors("Todos")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class EventoController : ControllerBase
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;
        private readonly IArchivoService _fichero;
        private readonly IServicioService _servicio;

        public EventoController(IConfiguration configuration, Context context, IArchivoService fichero, IServicioService servicio)
        {
            _configuration = configuration;
            _context = context;
            _fichero = fichero;
            _servicio = servicio;
        }

        /// <summary>
        /// Crear un evento
        /// </summary>
        // POST: api/Evento/CrearEvento
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CrearEvento(long idnegocio)
        {
            //TODO: Comprobar si este usuario tiene permiso para crear un evento en este negocio
            long idUsuario = User.Identity.ObtenerIdentificador();
            //TODO: Mirar si tengo permisos para crear un evento en este negocio

            var newEvento = new EVENTOS();
            newEvento.NOMBRE = "";
            newEvento.DESCRIPCION = "";
            newEvento.FECHA_INICIO = DateTime.Now;
            newEvento.FECHA_FIN = DateTime.Now;
            newEvento.ID_NEGOCIO = idnegocio;
            
            var fechaActual = DateTime.Now;
            newEvento.FECHA_CREACION = fechaActual;
            newEvento.FECHA_MODIFICACION = fechaActual;
            
            _context.Eventos.Add(newEvento);
            _context.SaveChanges();

            return await Task.FromResult(Ok(newEvento.ID_EVENTO));
        }

        /// <summary>
        /// Retorna un listado de los eventos de un negocio
        /// </summary>
        // GET: api/Evento/MisEventos
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<MisEventosResultModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> MisEventos(long idnegocio)
        {
            //TODO: Comprobar que el id negocio pertenece a un usuario con permisos
            var eventos = _context.Eventos.Where(x => x.ID_NEGOCIO == idnegocio).Select(x => new MisEventosResultModel
            {
                idevento = x.ID_EVENTO,
                nombre = x.NOMBRE,
                descripcion = x.DESCRIPCION,
                img_cabecera = _fichero.GetURLImage(ConfigApp.CabeceraEvento, x.URL_IMG_CABECERA),
                fecha_creacion = x.FECHA_CREACION,
                fecha_modificacion = x.FECHA_MODIFICACION
            }).ToList();

            return await Task.FromResult(Ok(eventos));
        }

        /// <summary>
        /// Retorna la información de un evento
        /// </summary>
        // GET: api/Evento/Informacion
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EventoInformacionModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Informacion(long idevento)
        {
            //TODO: Comprobar si este usuario tiene permiso para acceder a la información de este evento
            long idUsuario = User.Identity.ObtenerIdentificador();
            var evento = _context.Eventos.Find(idevento);
            if(evento == null) { throw new ArgumentException("No se ha encontrado este evento"); }

            //TODO: Meter en un servicio
            EventoInformacionModel resultEvento = new EventoInformacionModel();
            resultEvento.idevento = evento.ID_EVENTO;
            resultEvento.nombre = evento.NOMBRE;
            resultEvento.descripcion = evento.DESCRIPCION;
            resultEvento.img_cabecera = _fichero.GetURLImage(ConfigApp.CabeceraEvento, evento.URL_IMG_CABECERA);
            resultEvento.fecha_creacion = evento.FECHA_CREACION;
            resultEvento.fecha_modificacion = evento.FECHA_MODIFICACION;
            resultEvento.servicios = _servicio.GetServiciosNegocio(idevento);

            return await Task.FromResult(Ok(resultEvento));
        }

        /// <summary>
        /// Crear un nuevo servicio en un evento
        /// </summary>
        // POST: api/Evento/CrearServicio
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CrearServicio(long idevento)
        {
            //TODO: Comprobar si este usuario tiene permiso para crear un servicio en este evento
            long idUsuario = User.Identity.ObtenerIdentificador();
            
            _servicio.NuevoServicio(idevento);
            _context.SaveChanges();

            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// Actualiza los datos de un servicio
        /// </summary>
        // PUT: api/Evento/ActualizarEvento
        [HttpPut("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ActualizarEvento(EventoInformacionModel info)
        {
            //TODO: Comprobar si este usuario tiene permiso para crear un servicio en este evento
            long idUsuario = User.Identity.ObtenerIdentificador();

            var evento = _context.Eventos.Find(info.idevento);
            if (evento == null) { throw new ArgumentException("No se ha encontrado este evento"); }

            evento.NOMBRE = info.nombre;
            evento.DESCRIPCION = info.descripcion;

            //Actualizar servicios
            foreach (var servicio in info.servicios)
            {
                _servicio.ActualizarServicio(servicio);
            }
            _context.SaveChanges();

            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// Eliminar un servicio
        /// </summary>
        // DELETE: api/Evento/EliminarServicio
        [HttpDelete("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EliminarServicio(long idservicio)
        {
            //TODO: Comprobar si este usuario tiene permiso para eliminar el servicio
            long idUsuario = User.Identity.ObtenerIdentificador();

            var servicio = _context.Servicios.Find(idservicio);
            if (servicio == null) { throw new ArgumentException("No se ha encontrado este servicio"); }

            _context.Servicios.Remove(servicio);
            _context.SaveChanges();

            return await Task.FromResult(Ok());
        }
    }
}