using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelAndRequest.Common;
using ServiceLayer.Common.Account;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            return Ok(loginRequest);
        }

        public async Task<IActionResult> SignOut()
        {

            return Ok();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
