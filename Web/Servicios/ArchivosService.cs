using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using Web.Helpers;
using Web.Servicios.Interfaces;

namespace Web.Servicios
{
    public class ArchivosService : IArchivoService
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ArchivosService(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> Crear(byte[] file, string contentType, string extension, string container, string nombre)
        {
            string wwwrootPath = webHostEnvironment.WebRootPath;

            if (string.IsNullOrEmpty(wwwrootPath))
            {
                throw new Exception();
            }

            string carpetaArchivo = Path.Combine(wwwrootPath, container);
            if (!Directory.Exists(carpetaArchivo))
            {
                Directory.CreateDirectory(carpetaArchivo);
            }

            string nombreFinal = $"{nombre}{extension}";

            string rutaFinal = Path.Combine(carpetaArchivo, nombreFinal);

            await File.WriteAllBytesAsync(rutaFinal, file);

            string urlActual = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";

            string dbUrl = Path.Combine(urlActual, container, nombreFinal).Replace("\\", "/");

            return nombreFinal;
        }

        public Task Borrar(string ruta, string nombreFichero)
        {
            string wwwrootPath = webHostEnvironment.WebRootPath;

            if (string.IsNullOrEmpty(wwwrootPath))
            {
                throw new Exception();
            }

            var nombreArchivo = Path.GetFileName(ruta);

            string pathFinal = Path.Combine(wwwrootPath, nombreFichero, nombreArchivo);

            if (File.Exists(pathFinal))
            {
                File.Delete(pathFinal);
            }

            return Task.CompletedTask;
        }

        public async Task<string> GuardarFoto(IFormFile fichero, string path)
        {
            using var stream = new MemoryStream();
            await fichero.CopyToAsync(stream);
            var fileBytes = stream.ToArray();

            return await Crear(fileBytes, fichero.ContentType, Path.GetExtension(fichero.FileName), path, Guid.NewGuid().ToString());
        }

        public string GetURLImage(string ruta, string nombreFichero)
        {
            //string urlActual = string.Concat(MyStaticHelperClass.GetRequestScheme(), "://", MyStaticHelperClass.GetRequestHost());
            string urlActual = string.Concat(httpContextAccessor.HttpContext.Request.Scheme, "://", httpContextAccessor.HttpContext.Request.Host);
            if (string.IsNullOrEmpty(nombreFichero)) return "";
            string dbUrl = Path.Combine(urlActual, ruta, nombreFichero).Replace("\\", "/");
            return dbUrl;
        }
    }
}
