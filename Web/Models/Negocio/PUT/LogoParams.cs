using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Negocio.PUT
{
    public class LogoParams
    {
        [Required]
        public long id_negocio { get; set; }
        [Required]
        public IFormFile logo { get; set; }
    }
}
