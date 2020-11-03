using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JwtAuthDemo.Controllers
{
    public class LoginRequest
    {
        [Required]
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
