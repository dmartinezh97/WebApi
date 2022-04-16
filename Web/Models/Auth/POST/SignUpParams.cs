using System.ComponentModel.DataAnnotations;

namespace Web.Models.Auth.POST
{
    public class SignUpParams
    {
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellidos { get; set; }
        [Required]
        public string usuario { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string confirmPassword { get; set; }
    }
}
