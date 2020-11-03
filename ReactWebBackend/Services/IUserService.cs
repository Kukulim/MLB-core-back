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
        string GetUserId(string userName, string userPassword);
        string GetUserEmail(string userName, string password);
    }
}
