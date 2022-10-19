using Datos;
using Entidades.Negocios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web.Extens;
using Web.Helpers;
using Web.Middlewares;
using Web.Middlewares.Exceptions;
using Web.Models.Negocio;
using Web.Models.Negocio.PUT;
using Web.Servicios.Interfaces;

namespace Web.Controllers
{
    [EnableCors("Todos")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class NegocioController : ControllerBase
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;
        private readonly IArchivoService _fichero;
        private readonly INegocioService _negocioService;

        public NegocioController(IConfiguration configuration, Context context, IArchivoService fichero, INegocioService negocioService)
        {
            _configuration = configuration;
            _context = context;
            _fichero = fichero;
            _negocioService = negocioService;
        }

        /// <summary>
        /// Retorna un listado de negocios coincidentes con la busqueda
        /// </summary>
        // GET: api/Negocio/Buscar
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<NegocioResultModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Buscar(string query)
        {
            var negocios = _context.Negocio.Where(x => x.Nombre.Contains(query));

            return await Task.FromResult(Ok(negocios));
        }

        /// <summary>
        /// Crear un negocio
        /// </summary>
        // POST: api/Negocio/Crear
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NegocioResultModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Crear(NegocioParams negocioDTO)
        {
            //TODO: Comprobar que es un perfil con el rol de empresa
            //https://www.youtube.com/watch?v=pXeeTN88pc8

            long idUsuario = User.Identity.ObtenerIdentificador();

            var newNegocio = new NEGOCIOS();
            newNegocio.Nombre = negocioDTO.nombre;
            newNegocio.Descripcion = negocioDTO.descripcion;
            newNegocio.IdTipoNegocio = negocioDTO.tipo_negocio;
            _context.Negocio.Add(newNegocio);
            
            var newUsuarioNegocio = new NEGOCIOUSUARIO();
            newUsuarioNegocio.IdUsuario = idUsuario;
            newUsuarioNegocio.NEGOCIOS = newNegocio;
            
            _context.NegocioUsuario.Add(newUsuarioNegocio);
            _context.SaveChanges();

            var result = new NegocioResultModel();
            result.IdNegocio = newNegocio.IdNegocio;

            return await Task.FromResult(Ok(result));
        }


        /// <summary>
        /// Actualiza el logo de un negocio
        /// </summary>
        // PUT: api/Negocio/UpdateLogo
        [HttpPut("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateLogo(long idnegocio, [FromForm] LogoParams negocioDTO)
        {
            long idUsuario = User.Identity.ObtenerIdentificador();
            if (!_negocioService.TengoPermisos(idnegocio, idUsuario)) { return BadRequest("No tienes permiso para acceder a este negocio"); }

            var negocio = _context.Negocio.Find(idnegocio);
            if (negocio == null) { return BadRequest("No se ha encontrado el negocio"); }

            if (!string.IsNullOrEmpty(negocio.Logo))
            {
                await _fichero.Borrar(negocio.Logo, ConfigApp.LogoNegocio);
            }
            string fotoLogo = await _fichero.GuardarFoto(negocioDTO.logo, ConfigApp.LogoNegocio);
            if (!string.IsNullOrEmpty(fotoLogo))
            {
                negocio.Logo = fotoLogo;
            }
            _context.SaveChanges();

            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// Actualiza la imagen de cabecera de un negocio
        /// </summary>
        // PUT: api/Negocio/UpdateCabecera
        [HttpPut("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCabecera(long idnegocio, [FromForm] ImgCabeceraParams negocioDTO)
        {
            long idUsuario = User.Identity.ObtenerIdentificador();
            if (!_negocioService.TengoPermisos(idnegocio, idUsuario)) { return BadRequest("No tienes permiso para acceder a este negocio"); }

            var negocio = _context.Negocio.Find(idnegocio);
            if (negocio == null) { return BadRequest("No se ha encontrado el negocio"); }

            if (!string.IsNullOrEmpty(negocio.ImgCabecera))
            {
                await _fichero.Borrar(negocio.ImgCabecera, ConfigApp.CabeceraNegocio);
            }
            string fotoCabecera = await _fichero.GuardarFoto(negocioDTO.img_cabecera, ConfigApp.CabeceraNegocio);
            if (!string.IsNullOrEmpty(fotoCabecera))
            {
                negocio.ImgCabecera = fotoCabecera;
            }
            _context.SaveChanges();

            return await Task.FromResult(Ok());
        }


        ///// <summary>
        ///// Retorna un listado de los negocios del usuario
        ///// </summary>
        //// GET: api/Negocio/MisNegocios
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<MisNegociosResultModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> MisNegocios()
        {
            //TODO: Comprobar que es un perfil con el rol de empresa
            long idUsuario = User.Identity.ObtenerIdentificador();
            var listIdNegocios = _context.NegocioUsuario.Where(x => x.IdUsuario == idUsuario).Select(x => x.IdNegocio);
            var negocios = _context.Negocio.Where(x => listIdNegocios.Contains(x.IdNegocio)).Select(x => new MisNegociosResultModel
            {
                idnegocio = x.IdNegocio,
                nombre = x.Nombre,
                img_logo = _fichero.GetURLImage(ConfigApp.LogoNegocio, x.Logo),
                img_cabecera = _fichero.GetURLImage(ConfigApp.CabeceraNegocio, x.ImgCabecera)
            });

            return await Task.FromResult(Ok(negocios));
        }

        ///// <summary>
        ///// Retorna si tienes permisos para acceder al negocio
        ///// </summary>
        //// POST: api/Negocio/EsMiNegocio
        //[HttpPost("[action]")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<MisNegociosResultModel>))]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public async Task<IActionResult> EsMiNegocio(long idnegocio)
        //{
        //    long idUsuario = User.Identity.ObtenerIdentificador();
        //    var existe = _context.NegocioUsuario.Where(x => x.ID_NEGOCIO == idnegocio && x.ID_USUARIO == idUsuario).Any();
        //    if (existe)
        //    {
        //        return await Task.FromResult(Ok());
        //    }
        //    else return await Task.FromResult(Unauthorized());
        //}

        ///// <summary>
        ///// Retorna la información general de un negocio
        ///// </summary>
        //// GET: api/Negocio/InformacionGeneral
        //[HttpGet("[action]")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<MisNegociosResultModel>))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> InformacionGeneral(long idnegocio)
        //{
        //    //TODO: Comprobar que es la información a recibir tiene permiso para acceder a este negocio
        //    long idUsuario = User.Identity.ObtenerIdentificador();
        //    if (!_negocioService.TengoPermisos(idnegocio, idUsuario)) { return BadRequest("No tienes permiso para acceder a este negocio"); }
        //    var result = _context.Negocio.Where(x => x.ID_NEGOCIO == idnegocio).Select(x => new NegocioInformacionGeneralModel
        //    {
        //        idnegocio = x.ID_NEGOCIO,
        //        nombre = x.NOMBRE,
        //        slug = x.SLUG,
        //        descripcion = x.DESCRIPCION,
        //        img_logo = _fichero.GetURLImage(ConfigApp.LogoNegocio, x.URL_LOGO),
        //        img_cabecera = _fichero.GetURLImage(ConfigApp.CabeceraNegocio, x.URL_IMG_CABECERA),
        //        tipo_negocio = x.ID_TIPO_NEGOCIO,
        //        ubicacion = x.UBICACION,
        //        //ubicacion = x.ubi,
        //    }).FirstOrDefault();


        //    return await Task.FromResult(Ok(result));
        //}

        ///// <summary>
        ///// Actualiza la imagen de cabecera de un negocio
        ///// </summary>
        //// PUT: api/Negocio/UpdateCabecera
        //[HttpPut("[action]")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> UpdateDatos(NegocioInformacionGeneralModel negocioDTO)
        //{
        //    long idUsuario = User.Identity.ObtenerIdentificador();
        //    if (!_negocioService.TengoPermisos(negocioDTO.idnegocio, idUsuario)) { return BadRequest("No tienes permiso para acceder a este negocio"); }
        //    var negocio = _context.Negocio.Find(negocioDTO.idnegocio);
        //    if (negocio == null) { return BadRequest("No se ha encontrado el negocio"); }
        //    if(!_negocioService.SlugValido(negocio.ID_NEGOCIO, negocioDTO.slug)) { return BadRequest("El slug ya está en uso"); }

        //    negocio.NOMBRE = negocioDTO.nombre;
        //    negocio.SLUG = negocioDTO.slug;
        //    negocio.DESCRIPCION = negocioDTO.descripcion;
        //    negocio.ID_TIPO_NEGOCIO = negocioDTO.tipo_negocio;
        //    negocio.UBICACION = negocioDTO.ubicacion;

        //    _context.SaveChanges();

        //    return await Task.FromResult(Ok());
        //}

    }
}