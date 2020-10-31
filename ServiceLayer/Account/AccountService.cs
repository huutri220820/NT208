using DataLayer.EF;
using DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelAndRequest.Account;
using ModelAndRequest.API;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IConfiguration config;
        private readonly EShopDbContext eShopDbContext;

        public AccountService()
        {
        }
        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IConfiguration config, EShopDbContext eShopDbContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.eShopDbContext = eShopDbContext;
            this.config = config;
        }
        /// <summary>
        /// login service
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        public async Task<ApiResult<object>> Login(LoginRequest loginRequest)
        {
            // tim user neu khong co tra ve thong bao loi
            //sqlserver
            var user = await userManager.FindByNameAsync(loginRequest.username);
            //sqlite
            //var user = userManager.Users.FirstOrDefault(user => user.UserName == loginRequest.Username);
            if (user == null) return new ApiResult<object>(success: false, messge: "Khong tin thay user", payload: null);

            var result = await signInManager.PasswordSignInAsync(user, loginRequest.password, loginRequest.remember, true);
            if (!result.Succeeded)
                return new ApiResult<object>(success: false, messge: "Mat khau khong chinh xac", payload: null);

            //tao claims chua thong tin de luu vao payload cua token
            var roles = await userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.FullName),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, loginRequest.username)
            };
            var roleResult = "user";

            roleResult = roles.Contains("Admin") ? "admin" : roleResult;
            roleResult = roles.Contains("Sales") ? "sales" : roleResult;

            // ma hoa doi xung
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //tao token
            var token = new JwtSecurityToken(config["Tokens:Issuer"], config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            var tokenResult = new JwtSecurityTokenHandler().WriteToken(token);
            return new ApiResult<object>(success: true, messge: "Dang nhap thanh cong", payload: new { token = tokenResult, role = roleResult, id = user.Id });
        }

        /// <summary>
        /// regsier service
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <param name="isSale">if sale = true</param>
        /// <returns></returns>
        public async Task<ApiResult<bool>> Register(RegisterRequest registerRequest, bool isSale = false)
        {
            //sql server
            if (await userManager.FindByNameAsync(registerRequest.username) != null)
                //sqlite
                //if (userManager.Users.FirstOrDefault(user => user.UserName == registerRequest.Username) != null)
                return new ApiResult<bool>(success: false, messge: "User name da ton tai", payload: false);
            if (userManager.Users.FirstOrDefault(user => user.Email == registerRequest.email) != null)
                return new ApiResult<bool>(success: false, messge: "Email da ton tai", payload: false);

            var user = new User()
            {
                UserName = registerRequest.username,
                Email = registerRequest.email,
                IsMale = registerRequest.isMale,
                Dob = registerRequest.dob,
                FullName = registerRequest.fullName,
                PhoneNumber = registerRequest.phonenumber,
                SecurityStamp = string.Empty,
                EmailConfirmed = true
            };


            var result = await userManager.CreateAsync(user, registerRequest.password);


            if (result.Succeeded)
            {
                //sql server
                await userManager.AddToRoleAsync(user, "User");

                //sqlite
                //var roleUser = roleManager.Roles.FirstOrDefault(role => role.Name == (isSale ? "Sales" : "User"));
                //eShopDbContext.UserRoles.Add(new UserRole()
                //{
                //    UserId = user.Id,
                //    RoleId = roleUser.Id
                //});
                //await eShopDbContext.SaveChangesAsync();

                return new ApiResult<bool>(success: true, messge: "Dang ki thanh cong", payload: true);
            }

            return new ApiResult<bool>(success: false, messge: string.Join("", result.Errors.Select(er => er.Description)), payload: false);
        }

        /// <summary>
        /// create sales service (role admin)
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        public async Task<ApiResult<bool>> CreateSales(RegisterRequest registerRequest)
        {
            return await Register(registerRequest, true);
        }

        /// <summary>
        /// get all account (role admin)
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<ApiResult<List<AccountModel>>> GetAllAccount(string role)
        {
            var data = from u in eShopDbContext.Users
                       join ur in eShopDbContext.UserRoles on u.Id equals ur.UserId
                       join r in eShopDbContext.Roles on ur.RoleId equals r.Id
                       where r.Name == role
                       select new { user = u };
    

            if (data == null)
                return new ApiResult<List<AccountModel>>(success: false, messge: "Khong tim thay user", payload: null);

            var users = await data.Select(data => new AccountModel()
            {
                id = data.user.Id,
                username = data.user.UserName,
                fullName = data.user.FullName,
                isMale =data.user.IsMale,
                email =data.user.Email,
                phonenumber =data.user.PhoneNumber,
                dob =data.user.Dob,
                address =data.user.Address,
                avatar = data.user.Avatar,
            }).ToListAsync();

            if(users == null)
                return new ApiResult<List<AccountModel>>(success: false, messge: "Khong tim thay user", payload: null);

            return new ApiResult<List<AccountModel>>(success: false, messge: "Tim thay danh sach user", payload: users);

        }
        /// <summary>
        /// delete accoubt  (sales
        /// </summary>
        /// <param name="id"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<ApiResult<bool>> DeleteAccount(Guid id, string role)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            var roles = await userManager.GetRolesAsync(user);
            if(!roles.Contains(role))
                return new ApiResult<bool>(success: false, messge: "Khong co quyen xoa user nay", payload: false);

            if (user == null)
                return new ApiResult<bool>(success: false, messge: "Khong tim thay user", payload: false);

            var result = await userManager.DeleteAsync(user);

            if(!result.Succeeded)
                return new ApiResult<bool>(success: false, messge: "Xoa khong thanh cong", payload: false);

            return new ApiResult<bool>(success: false, messge: "Xoa thanh cong", payload: true);
        }
        /// <summary>
        /// get info account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResult<AccountModel>> GetById(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());

            if (user == null)
                return new ApiResult<AccountModel>(success: false, messge: "Khong tim thay user", payload: null);

            var result = new AccountModel()
            {
                id = user.Id,
                username = user.UserName,
                fullName = user.FullName,
                email = user.Email,
                phonenumber = user.PhoneNumber,
                address = user.Address,
                dob = user.Dob,
                avatar = user.Avatar,
                isMale = user.IsMale
            };

            return new ApiResult<AccountModel>(success: true, messge: "thanh cong", payload: result);
        }
    }
}
