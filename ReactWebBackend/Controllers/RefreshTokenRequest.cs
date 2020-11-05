using System.Text.Json.Serialization;

namespace JwtAuthDemo.Controllers
{
    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; }
    }
}
