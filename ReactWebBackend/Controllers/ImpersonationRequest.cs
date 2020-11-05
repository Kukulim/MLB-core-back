using System.Text.Json.Serialization;

namespace JwtAuthDemo.Controllers
{
    public class ImpersonationRequest
    {
        public string UserName { get; set; }
    }
}
