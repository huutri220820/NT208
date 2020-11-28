using Microsoft.AspNetCore.Mvc;
using ModelAndRequest.Cart;
using ServiceLayer.CartService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("/api/cart/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <param name="isReduce">true : cap nhat so luong cua muot cartItem = so luong gui den, false: cong don</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/cart/sync/{userId}")]
        public async Task<IActionResult> SyncCart(Guid userId, ListCartRequest request, bool isReduce = false)
        {
            var result = await cartService.Sync(userId, request, isReduce);
            return Ok(result);
        }


        [HttpGet]
        [Route("/api/cart/clear/{userId}")]
        public async Task<IActionResult> ClearCart(Guid userId)
        {
            var result = await cartService.Clear(userId);
            return Ok(result);
        }
    }
}
