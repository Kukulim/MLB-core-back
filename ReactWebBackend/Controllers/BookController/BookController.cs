using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactWebBackend.Models;
using ReactWebBackend.Services.BookRepository;

namespace ReactWebBackend.Controllers
{

        [Route("api/books")]
        [ApiController]
        public class BookController : ControllerBase
        {
            private readonly IBookRepository bookRepository;

            public BookController(IBookRepository bookRepository)
            {
                this.bookRepository = bookRepository;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Book>>> GetAll()
            {
                var all = await bookRepository.GetAll();
                return Ok(all);
            }
            [HttpGet("{id}")]
            public async Task<ActionResult<Book>> Get(string id)
            {
                var product = await bookRepository.Get(id);
                return Ok(product);
            }
            [HttpPost]
            public async Task<ActionResult> Post(Book book)
            {
                await bookRepository.Create(book);
                return Ok();
            }
            [HttpDelete("{id}")]
            public ActionResult Delete(string id)
            {
                bookRepository.Delete(id);
                return Ok();
            }
        }
    }

