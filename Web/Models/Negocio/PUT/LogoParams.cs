﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Negocio.PUT
{
    public class LogoParams
    {
        [Required]
        public IFormFile logo { get; set; }
    }
}
