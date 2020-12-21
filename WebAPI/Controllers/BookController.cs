//Vo Huu Tri - 18521531 UIT
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAndRequest.Book;
using ServiceLayer.BookServices;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/book/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        [Route("/api/book/all")]
        public async Task<IActionResult> GetAllBook()
        {
            var result = await bookService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/book/query")]
        public async Task<IActionResult> GetBookPagging(int page = 1, int size = 10, string orderBy = "Price", bool dsc = false, int? categoryId = null, string search = null, bool? isSuspend = null)

        {
            var result = await bookService.GetBook(page, size, orderBy, dsc, categoryId, search, isSuspend);
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/book/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var result = await bookService.GetBookById(id);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(policy: "Admin")]
        [Route("/api/admin/book")]
        public async Task<IActionResult> AddBook([FromBody] BookRequest bookRequest)
        {
            var result = await bookService.AddBook(bookRequest);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(policy: "Admin")]
        [Route("/api/admin/book/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookRequest bookRequest)
        {
            var result = await bookService.EditBook(id, bookRequest);
            return Ok(result);
        }

        [HttpDelete]
        [Authorize(policy: "Admin")]
        [Route("/api/admin/book")]
        public async Task<IActionResult> RemoveBook(int id)
        {
            var result = await bookService.DeleteBook(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/admin/book/top/{option}")]
        public async Task<IActionResult> RatingBook(string option, int page = 1, int size = 6)
        {
            var result = await bookService.GetBook(page: page, size: size, orderBy: option + "Score", dsc: true, isSuspend: false);
            return Ok(result);
        }

        [HttpPost]
        [Route("/api/image")]
        public IActionResult PostImage(IFormFile image)
        {
            var result = bookService.TestImage(image);
            return Ok(result);
        }
    }
}