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

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _dbCollection.FindAsync(_ => true).Result.ToListAsync();
        }
    }
}
