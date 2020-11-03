using ReactWebBackend.Models;
using ReactWebBackend.Services.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWebBackend.Services.BookRepository
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        IEnumerable<Book> GetAllbooks(string userId);
    }
}
