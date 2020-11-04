using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelAndRequest.API;
using ModelAndRequest.Book;
using ServiceLayer.BookServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        [Route("/api/book/get")]
        public async Task<IActionResult> GetBookPagging(int page = 1, int size = 10, string orderBy = "Price", bool dsc = false, int? categoryId = null, string search = null)
        {
            var result = await bookService.GetBook(page, size, orderBy, dsc, categoryId, search);
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/book/all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await bookService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/book/detail/{id}")]
        public async Task<IActionResult> getById(int id)
        {
            var result = await bookService.GetBookById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("/api/book/add")]
        public async Task<IActionResult> AddBook([FromForm] BookRequest bookRequest)
        {
            var result = await bookService.AddBook(bookRequest);
            return Ok(result);
        }

        [HttpPost]
        [Route("/api/book/adds")]
        public async Task<IActionResult> AddBookS([FromBody] BookRequest bookRequest)
        {
            var result = await bookService.AddBook(bookRequest);
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/book")]
        public async Task<IActionResult> RemoveBook(int id)
        {
            var result = await bookService.DeleteBook(id);
            return Ok(result);
        }
    }
}
