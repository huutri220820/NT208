//Vo Huu Tri - 18521531 UIT
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelAndRequest.Cart;
using ServiceLayer.CartService;
using System;
using System.Linq;
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

        [Authorize(policy: "User")]
        [HttpGet]
        public IActionResult get()
        {
            var userId = Guid.Parse(User.Claims.First(x => x.Type == "userId").Value.ToString());
            var result = cartService.Get(userId);
            return Ok(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <param name="isReduce">true : cap nhat so luong cua muot cartItem = so luong gui den, false: cong don</param>
        /// <returns></returns>
        ///
        [Authorize(policy: "User")]
        [HttpPost]
        public async Task<IActionResult> post(ListCartRequest request, bool isReduce = false)
        {
            var userId = Guid.Parse(User.Claims.First(x => x.Type == "userId").Value.ToString());
            var result = await cartService.Post(userId, request, isReduce);
            return Ok(result);
        }

        [HttpDelete]
        [Authorize(policy: "User")]
        [Route("/api/cart/clear")]
        public async Task<IActionResult> ClearCart()
        {
            var userId = Guid.Parse(User.Claims.First(x => x.Type == "userId").Value.ToString());
            var result = await cartService.Clear(userId);
            return Ok();
        }

        [Authorize(policy: "User")]
        [HttpDelete]
        public async Task<IActionResult> delete(int bookId)
        {
            var userId = Guid.Parse(User.Claims.First(x => x.Type == "userId").Value.ToString());
            var result = await cartService.Delete(userId, bookId);
            return Ok(result);
        }
    }
}