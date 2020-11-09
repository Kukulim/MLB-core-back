using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using ReactWebBackend.DbContext;
using ReactWebBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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



        public bool IsValidUserCredentials(string userName, string password)
            {
                _logger.LogInformation($"Validating user [{userName}]");
                if (string.IsNullOrWhiteSpace(userName))
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    return false;
                }

            var user = _dbCollection.Find<Users>(user => user.UserName == userName && user.Password== password).FirstOrDefault();

            if (user != null)
            {
                return true;
            }

            return false;
            }

            //public bool IsAnExistingUser(string userName)
            //{
            //    return true;
            //}

            public string GetUserRole(string userName)
            {
                //if (!IsAnExistingUser(userName))
                //{
                //    return string.Empty;
                //}

                if (userName == "admin")
                {
                    return UserRoles.Admin;
                }

                return UserRoles.BasicUser;
            }

        public Users Create(Users user)
        {
            _dbCollection.InsertOne(user);
            return user;
        }
        public Users GetUserByEmail(string userName, string userEmail)
        {
            return _dbCollection.Find<Users>(user => user.UserName == userName && user.Email == userEmail).FirstOrDefault();
        }
        public Users GetUserByPassword(string userName, string password)
        {
            return _dbCollection.Find<Users>(user => user.UserName == userName && user.Password == password).FirstOrDefault();
        }
        public Users Edit(Users user)
        {
            var filter = Builders<Users>.Filter.Eq(doc => doc.Id, user.Id);
            _dbCollection.FindOneAndReplace(filter, user);
            return user;
        }
        public void Delete(Users user)
        {
            var builder = Builders<Users>.Filter;
            var filter = builder.Eq(x => x.Email, user.Email) & builder.Eq(x=>x.UserName, user.UserName) & builder.Eq(x => x.Password, user.Password);
            _dbCollection.FindOneAndDelete(filter);
        }
    }
}

