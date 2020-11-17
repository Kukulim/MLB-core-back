using ReactWebBackend.Models.UsersModels;
using System.Collections.Generic;

namespace ReactWebBackend.Services
{
    public interface IUserService
    {
        //bool IsAnExistingUser(string userName);
        bool IsValidUserCredentials(string userName, string password);
        bool IsAnExistingUser(string userName, string UserEmail);
        string GetUserRole(string userName);
        public List<Users> GetAll();
        public Users Create(Users user);
        Users GetUserByPassword(string userName, string password);
        Users GetUserByEmail(string userEmail);
        Users Edit(Users user);
        void Delete(Users user);
    }
}
