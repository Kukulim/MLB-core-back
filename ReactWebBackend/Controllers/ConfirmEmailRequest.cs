using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWebBackend.Controllers
{
    public class ConfirmEmailRequest
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
    }
}
