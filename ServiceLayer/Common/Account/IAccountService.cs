using ModelAndRequest.API;
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
        Task<ApiResult<object>> Login(LoginRequest loginRequest);
        Task<ApiResult<bool>> Register(RegisterRequest registerRequest, bool isSale = false);
        Task<ApiResult<bool>> CreateSales(RegisterRequest registerRequest);
    }
}
