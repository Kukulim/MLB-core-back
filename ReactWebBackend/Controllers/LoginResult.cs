using System.Text.Json.Serialization;

namespace JwtAuthDemo.Controllers
{
    public class LoginResult
    {
        public string UserName { get; set; }

        public string Role { get; set; }

        public string OriginalUserName { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
