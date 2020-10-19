using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWebBackend.DbContext
{
    public interface IMongoBookDBContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
