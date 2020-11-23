using ReactWebBackend.Models.UsersModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWebBackend.Models.AccountModels
{
    public class EditAccountRequest
    {
        public string Email { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
    }
}
