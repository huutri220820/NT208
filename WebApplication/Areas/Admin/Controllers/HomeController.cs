using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.EF;
using DataLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using ServiceLayer.Admin.Product;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public readonly IProductService productService;
        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }


        [Authorize(Policy = "Administrator")]
        public IActionResult Index()
        {
            TempData["avatar"] = Images.AvatarDefault;
            TempData["account"] = "Admin";
            return View();
        }
  
    }
}
