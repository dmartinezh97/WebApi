using System.ComponentModel.DataAnnotations;

namespace Web.Models.Auth.POST
{
    public class LoginParams
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
