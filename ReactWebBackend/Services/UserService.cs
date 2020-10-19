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

            // inject your database here for user validation
            public UserService(ILogger<UserService> logger, IMongoBookDBContext context)
            {
                _logger = logger;
                _mongoContext = context;
                _dbCollection = _mongoContext.GetCollection<Users>("users");
        }

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
        }
    }

