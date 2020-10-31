using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(200); 
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            return Ok(id);
        }

        [HttpGet]
        [Authorize(policy: "Sales")]
        public IActionResult get(int page, int limit, string search)
        {
            return Ok();
        }


    }
}
