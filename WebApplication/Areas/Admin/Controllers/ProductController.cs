using DataLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Admin.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await this.productService.GetAllProduct();
            if (model == null)
            {
                ViewBag.noData = 1;
                return View();
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var product = this.productService.GetProductById(id);

            return Ok(product);
        }
    }
}
