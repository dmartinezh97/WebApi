using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Web.Servicios.Interfaces
{
    public interface IArchivoService
    {
        public Task<string> Crear(byte[] file, string contentType, string extension, string container, string nombre);
        public Task Borrar(string ruta, string nombreFichero);
        public Task<string> GuardarFoto(IFormFile fichero, string ruta);
        string GetURLImage(string ruta, string nombreFichero);
    }
}
