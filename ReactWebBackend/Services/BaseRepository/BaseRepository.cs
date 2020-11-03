using MongoDB.Bson;
using MongoDB.Driver;
using ReactWebBackend.DbContext;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWebBackend.Services.BaseRepository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoBookDBContext _mongoContext;
        protected IMongoCollection<TEntity> _dbCollection;

        protected BaseRepository(IMongoBookDBContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public virtual async Task Create(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }
            _dbCollection = _mongoContext.GetCollection<TEntity>(typeof(TEntity).Name);
            await _dbCollection.InsertOneAsync(obj);
        }

        public void Delete(string id)
        {
            //ex. 5dc1039a1521eaa36835e541

            var objectId = new ObjectId(id);
            _dbCollection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", objectId));

        }
        public virtual void Update(TEntity obj)
        {
            _dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq(" _id ", obj.GetId()), obj);
        }

        public async Task<TEntity> Get(string id)
        {
            //ex. 5dc1039a1521eaa36835e541

            var objectId = new ObjectId(id);

            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);

            _dbCollection = _mongoContext.GetCollection<TEntity>(typeof(TEntity).Name);

            return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();

        }


        public virtual async Task<IEnumerable<TEntity>> GetAll(string userId)
        {

            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("UserId", userId);

            _dbCollection = _mongoContext.GetCollection<TEntity>(typeof(TEntity).Name);
            return await _dbCollection.FindAsync(filter).Result.ToListAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
