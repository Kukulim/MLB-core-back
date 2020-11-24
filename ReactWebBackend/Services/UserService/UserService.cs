using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using ReactWebBackend.DbContext;
using ReactWebBackend.Models.UsersModels;
using System.Collections.Generic;
using System.Linq;

namespace ReactWebBackend.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IMongoBookDBContext _mongoContext;
        protected IMongoCollection<Users> _dbCollection;

        public UserService(ILogger<UserService> logger, IMongoBookDBContext context)
        {
            _logger = logger;
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<Users>("Users");
        }

        public List<Users> GetAll() =>
                _dbCollection.Find(user => true).ToList();

        public bool IsAnExistingUser(string userName, string UserEmail)
        {
            var user = _dbCollection.Find<Users>(user => user.UserName == userName || user.Email == UserEmail).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public Users Create(Users user)
        {
            _dbCollection.InsertOne(user);
            return user;
        }

        public Users GetUserByEmail(string userEmail)
        {
            return _dbCollection.Find<Users>(user => user.Email == userEmail).FirstOrDefault();
        }

        public Users GetUserByPassword(string userName, string password)
        {
            return _dbCollection.Find<Users>(user => user.UserName == userName && user.Password == password).FirstOrDefault();
        }

        public Users Edit(Users user)
        {
            var builder = Builders<Users>.Filter;
            var filter = builder.Eq(x => x.Email, user.Email);
            var userToEdit = _dbCollection.Find<Users>(u => u.Email == user.Email).FirstOrDefault();

            userToEdit.ShippingAddress = user.ShippingAddress;
            _dbCollection.FindOneAndReplace(filter, userToEdit);
            return user;
        }

        public void Delete(Users user)
        {
            var builder = Builders<Users>.Filter;
            var filter = builder.Eq(x => x.Email, user.Email) & builder.Eq(x => x.UserName, user.UserName) & builder.Eq(x => x.Password, user.Password);
            _dbCollection.FindOneAndDelete(filter);
        }
    }
}