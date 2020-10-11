using DataLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Admin.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize(Policy = "Sales")]
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        
        public BookController(IBookService productService)
        {
            this.bookService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? categoryId = null)
        {
            ViewData["avatar"] = HttpContext.Session.GetString("avatar");
            ViewData["account"] = HttpContext.Session.GetString("account");
            var bookView = await this.bookService.GetAllBook(categoryId);
            if (bookView == null)
            {
                ViewBag.noData = 1;
                return View();
            }
            return Ok(bookView);
        }
        public IActionResult Detail(int id)
        {
            ViewData["avatar"] = HttpContext.Session.GetString("avatar");
            ViewData["account"] = HttpContext.Session.GetString("account");
            var book = this.bookService.GetBookById(id);
            if (book == null)
            {
                ViewBag.isNull = 1;
                return View();
            }

            return Ok(book);
        }
    }
}
