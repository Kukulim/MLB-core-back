using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReactWebBackend.JwtAuth
{
    public class JwtAuthResult
    {
        public string AccessToken { get; set; }

        public RefreshToken RefreshToken { get; set; }
    }
}
