using ReactWebBackend.Models.UsersModels;
using System.Collections.Generic;

namespace ReactWebBackend.Services
{
    public interface IUserService
    {
        //bool IsAnExistingUser(string userName);
        bool IsAnExistingUser(string userName, string UserEmail);
        public List<Users> GetAll();
        public Users Create(Users user);
        Users GetUserByPassword(string userName, string password);
        Users GetUserByEmail(string userEmail);
        Users Edit(Users user);
        void Delete(Users user);
    }
}
