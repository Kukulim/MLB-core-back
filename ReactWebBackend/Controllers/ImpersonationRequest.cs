using System.Text.Json.Serialization;

namespace JwtAuthDemo.Controllers
{
    public class ImpersonationRequest
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
    }
}
