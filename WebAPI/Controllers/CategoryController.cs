using Microsoft.AspNetCore.Mvc;
using ModelAndRequest.Category;
using ServiceLayer.CategoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/category/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> add([FromBody] CategoryRequest categoryRequest)
        {
            var result = await categoryService.AddCategory(categoryRequest);
            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> all()
        {
            var result = await categoryService.GetAllCategory();
            return Ok(result);
        }

        [Route("/api/category/{id}")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] CategoryRequest categoryRequest)
        {
            var result = await categoryService.EditCategory(id, categoryRequest);
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/category/{id}/books")]
        public async Task<IActionResult> GetAllBook(int id)
        {
            var result = await categoryService.GetAllBook(id);
            return Ok(result);
        }

    }
}
