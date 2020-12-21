//Vo Huu Tri - 18521531 UIT
using ModelAndRequest.API;
using ModelAndRequest.Cart;
using System;
using System.Collections.Generic;
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