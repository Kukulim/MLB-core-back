using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ReactWebBackend.Models;
using ReactWebBackend.Services.BookRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml;

namespace ReactWebBackend.Controllers
{
    [Route("api/books")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        private readonly IConfiguration configuration;

        public BookController(IBookRepository bookRepository, IConfiguration configuration)
        {
            this.bookRepository = bookRepository;
            this.configuration = configuration;
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

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(string id)
        {
            var product = await bookRepository.Get(id);
            return Ok(product);
        }

        [AllowAnonymous]
        [HttpGet("search/{name}")]
        public async Task<ActionResult> Search(string name)
        {
            var Result = String.Empty;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(configuration["BookAPI:url"] + name))
                {
                    XmlDocument doc = new XmlDocument();
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    doc.LoadXml(apiResponse);
                    Result = JsonConvert.SerializeXmlNode(doc);
                }
            }
            return Ok(Result);
        }

        [AllowAnonymous]
        [HttpGet("detailssearch/{name}&{author}")]
        public async Task<ActionResult> DetailsSearch(string name, string author)
        {
            var Result = String.Empty;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(configuration["BookAPI:baseurl"]+ "/book/title.xml?author=" + author+ "&key="+ configuration["BookAPI:key"]+ "&title="+name))
                {
                    XmlDocument doc = new XmlDocument();
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    doc.LoadXml(apiResponse);
                    Result = JsonConvert.SerializeXmlNode(doc);
                }
            }
            return Ok(Result);
        }

        [HttpPost("CreateAuction")]
        public async Task<ActionResult> Post(Book book)
        {
            await bookRepository.Create(book);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            bookRepository.Delete(id);
            return Ok();
        }

        [HttpPost("UploadImage"), DisableRequestSizeLimit]
        public IActionResult UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fileNameToInsert = Guid.NewGuid() + fileName;
                    var fullPath = Path.Combine(pathToSave, fileNameToInsert);
                    var dbPath = Path.Combine(folderName, fileNameToInsert);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}