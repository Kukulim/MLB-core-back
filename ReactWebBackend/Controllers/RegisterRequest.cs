using JwtAuthDemo.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReactWebBackend.Controllers
{
    public class RegisterRequest :LoginRequest
    {
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
