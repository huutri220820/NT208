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
            var result = await accountService.Login(loginRequest);
            if (result.isLogin == true)
                if (result.Role == "admin")
                    return RedirectToRoute("area", new { controller = "Home", action = "Index", area = "Admin" });                
                else
                    return RedirectToRoute("default", new { controller = "Home", action = "Index" });
            
            ViewBag.LoginFail = 1;

            return View(loginRequest);
        }

        public async Task<IActionResult> SignOut()
        {
            await accountService.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
