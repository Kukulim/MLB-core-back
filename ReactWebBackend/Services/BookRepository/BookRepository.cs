using MongoDB.Driver;
using ReactWebBackend.DbContext;
using ReactWebBackend.Models;
using ReactWebBackend.Services.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWebBackend.Services.BookRepository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(IMongoBookDBContext context) : base(context)
        {
        }
        public IEnumerable<Book> GetAllbooks(string name)
        {
            _dbCollection = _mongoContext.GetCollection<Book>(typeof(Book).Name);
            var all = _dbCollection.Find(b => b.Name == name).ToList();
            return all;
        }
    }
}
