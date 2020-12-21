//Vo Huu Tri - 18521531 UIT
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok(200);
        }
    }
}