using ReactWebBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWebBackend.Services
{
    public interface IUserService
    {
        //bool IsAnExistingUser(string userName);
        bool IsValidUserCredentials(string userName, string password);
        string GetUserRole(string userName);
        public List<Users> GetAll();
        public Users Create(Users user);
        Users GetUserByPassword(string userName, string userEmail);
        Users GetUserByEmail(string userName, string password);
        Users Edit(Users user);
    }
}
