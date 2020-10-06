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
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["avatar"] = HttpContext.Session.GetString("avatar");
            ViewData["account"] = HttpContext.Session.GetString("account");
            var productViews = await this.productService.GetAllProduct();
            if (productViews == null)
            {
                ViewBag.noData = 1;
                return View();
            }
            return View(productViews);
        }
        public IActionResult Detail(int id)
        {
            ViewData["avatar"] = HttpContext.Session.GetString("avatar");
            ViewData["account"] = HttpContext.Session.GetString("account");
            var product = this.productService.GetProductById(id);
            if (product == null)
            {
                ViewBag.isNull = 1;
                return View();
            }

            return View(product);
        }
    }
}
