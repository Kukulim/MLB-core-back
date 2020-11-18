using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactWebBackend.Models;
using ReactWebBackend.Services.BookRepository;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReactWebBackend.Controllers
{
    [Route("api/books")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var all = bookRepository.GetAll();
            return Ok(all.Result);
        }
        [HttpGet("GetAllMy")]
        public ActionResult<IEnumerable<Book>> GetAllMy()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var all = bookRepository.GetAllMy(userId);
            return Ok(all.Result);
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            book.UserId = userId;
            await bookRepository.Create(book);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            bookRepository.Delete(id);
            return Ok();
        }
    }
}