using DataLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using ModelAndRequest.Cart;
using ModelAndRequest.Order;
using ServiceLayer.OrderServices;
using System;
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

        [Route("{orderId}")]
        [HttpGet]
        public async Task<IActionResult> detail(int orderId)
        {
            var result = await orderService.GetGetOrderDetail(orderId);
            return Ok(result);
        }

        [Route("{orderId}")]
        [HttpPost]
        public async Task<IActionResult> update(int orderId, OrderRequest orderRequest)
        {
            var result = await orderService.UpdateOrder(orderId, orderRequest);
            return Ok(result);
        }

       

        [HttpPost]
        public IActionResult create([FromBody] ListCartRequest listCartRequest)
        {
            var result = orderService.CreateOrder(listCartRequest);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> add(OrderDetailRequest orderDetailRequest)
        {
            var result = await orderService.AddOrder(orderDetailRequest.ListCartRequest, orderDetailRequest.OrderRequest);
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/admin/order/all")]
        public async Task<IActionResult> getAllOrder()
        {
            var result = await orderService.GetAllOrders();
            return Ok(result);
        }

    }
}
