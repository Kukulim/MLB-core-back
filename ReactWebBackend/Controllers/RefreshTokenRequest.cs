using System.Text.Json.Serialization;

namespace JwtAuthDemo.Controllers
{
    public class RefreshTokenRequest
    {
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
