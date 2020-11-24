﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JwtAuthDemo.Controllers
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
