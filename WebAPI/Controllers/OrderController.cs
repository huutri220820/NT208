//Vo Huu Tri - 18521531 UIT
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelAndRequest.Cart;
using ModelAndRequest.Order;
using ServiceLayer.OrderServices;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/order/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> add(OrderDetailRequest orderDetailRequest)
        {
            var userId = Guid.Parse(User.Claims.First(x => x.Type == "userId").Value.ToString());
            orderDetailRequest.OrderRequest.UserId = userId;
            var result = await orderService.AddOrder(orderDetailRequest.ListCartRequest, orderDetailRequest.OrderRequest);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult create([FromBody] ListCartRequest listCartRequest)
        {
            var result = orderService.CreateOrder(listCartRequest);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("/api/order/detail/{orderId}")]
        public async Task<IActionResult> detail(int orderId)
        {
            var result = await orderService.GetGetOrderDetail(orderId);
            return Ok(result);
        }

        [Authorize(policy: "Sales")]
        [HttpPost("/api/order/admin/{orderId}")]
        public async Task<IActionResult> update(int orderId, OrderRequest orderRequest)
        {
            var result = await orderService.UpdateOrder(orderId, orderRequest);
            return Ok(result);
        }

        [HttpGet]
        [Authorize(policy: "Sales")]
        [Route("/api/admin/order/all")]
        public async Task<IActionResult> getAllOrder()
        {
            var result = await orderService.GetAllOrders();
            return Ok(result);
        }

        [HttpGet]
        [Authorize(policy: "User")]
        public IActionResult user(bool isDelete = false)
        {
            var userId = Guid.Parse(User.Claims.First(x => x.Type == "userId").Value);
            var result = orderService.GetOrdersUser(userId, isDelete);
            return Ok(result);
        }

        /// <summary>
        /// don hang chi duoc huy neu vua moi tao, sau khi duyet thi se khong the
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpDelete("{orderId}")]
        [Authorize(policy: "User")]
        public async Task<IActionResult> delete(int orderId)
        {
            var userId = Guid.Parse(User.Claims.First(x => x.Type == "userId").Value);
            var result = await orderService.DeleteOrder(userId, orderId);
            return Ok(0);
        }    
    }
}