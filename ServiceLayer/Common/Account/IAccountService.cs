using ModelAndRequest.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Common.Account
{
    public interface IAccountService
    {
        Task<(bool isLogin, string Role)> Login(LoginRequest loginRequest);
        Task SignOut();
    }
}
