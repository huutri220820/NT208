using ModelAndRequest.API;
using ModelAndRequest.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.CartService
{
    public interface ICartService
    {
        Task<ApiResult<bool>> Delete(Guid userId, int bookId);
        ApiResult<List<CartViewModel>> Get(Guid userId);
        Task<ApiResult<List<CartViewModel>>> Post(Guid userId, ListCartRequest listCart, bool isReduce);
        Task<ApiResult<bool>> Clear(Guid userId);
    }
}
