//Vo Huu Tri - 18521531 UIT
using ModelAndRequest.API;
using ModelAndRequest.Cart;
using ModelAndRequest.Order;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.OrderServices
{
    public interface IOrderService
    {
        //truyen vao userId, sau do lay cac san pham nam trong gio hang cua User nay va tien hanh tao don hang
        ApiResult<object> CreateOrder(ListCartRequest ListCartRequest);

        Task<ApiResult<bool>> AddOrder(ListCartRequest ListCartRequest, OrderRequest OrderRequest);

        Task<ApiResult<bool>> UpdateOrder(int OrderId, OrderRequest OrderRequest);

        Task<ApiResult<bool>> DeleteOrder(Guid UserId, int OrderId);

        Task<ApiResult<List<OrderViewModel>>> GetOrdersUser(Guid UserId);

        Task<ApiResult<List<OrderViewModel>>> GetAllOrders();

        Task<ApiResult<List<OrderDetailViewModel>>> GetGetOrderDetail(int OrderId);
    }
}