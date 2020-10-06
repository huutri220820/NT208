using DataLayer.EF;
using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModelAndRequest.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.Common.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AccountService()
        {

        }
        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<(bool isLogin, string Role)> Login(LoginRequest loginRequest)
        {
            Console.WriteLine("----------------------Sql Server");
            var user = await userManager.FindByNameAsync(loginRequest.Username);

            //Console.WriteLine("----------------------Sqlite");
            //var user = userManager.Users.Where(x => x.UserName == loginRequest.Username).FirstOrDefault();

            if (user != null)
            {
                var loginResult = await signInManager.PasswordSignInAsync(user, loginRequest.Password, loginRequest.Remember, lockoutOnFailure: false);
                if (loginResult.Succeeded)
                {
                    httpContextAccessor.HttpContext.Session.SetString("avatar", Images.AvatarDefault);
                    httpContextAccessor.HttpContext.Session.SetString("account", "Admin");

                    var admin = user.UserRoles.Find(x => x.Role.Name == "Administrator");
                    if (admin == null)
                    {
                        var sales = user.UserRoles.Find(x => x.Role.Name == "Sales");
                        if (sales != null)
                            return (true, "sales");//login thanh cong, role sales
                        else
                            return (true, "user");// login thanh cong, role user
                    }
                    else
                        return (true, "admin"); //login thanh cong, role admin
                }
            }
            return (false, "public");
        }

        public async Task SignOut()
        {
            await signInManager.SignOutAsync();
        }
    }
}
