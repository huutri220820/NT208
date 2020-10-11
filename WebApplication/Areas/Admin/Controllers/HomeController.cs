using DataLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Admin.Product;
using System.Net.Http;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IBookService bookService;
        public HomeController(IBookService productService)
        {
            this.bookService = productService;
        }


        [Authorize(Policy = "Sales")]
        public IActionResult Index()
        {
            ViewData["avatar"] = HttpContext.Session.GetString("avatar");
            ViewData["account"] = HttpContext.Session.GetString("account");
            return View();
        }

    }
}
