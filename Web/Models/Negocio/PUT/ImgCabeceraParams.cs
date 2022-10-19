using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Negocio.PUT
{
    public class ImgCabeceraParams
    {
        [Required]
        public IFormFile img_cabecera { get; set; }
    }
}
