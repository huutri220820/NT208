using DataLayer.EF;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ModelAndRequest.API;
using ModelAndRequest.Cart;
using ModelAndRequest.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ServiceLayer.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly EShopDbContext eShopDbContext;

        public OrderService(EShopDbContext eShopDbContext)
        {
            this.eShopDbContext = eShopDbContext;
        }

        public ApiResult<object> CreateOrder(ListCartRequest ListCartRequest)
        {
            List<CartViewModel> cartViews = new List<CartViewModel>();
            decimal totalPrice = 0;
            ListCartRequest?.CartRequests.ForEach(cart =>
            {
                var book = eShopDbContext.Books.Find(cart.bookId);
                if (book != null && book.Available > 0)
                {
                    cartViews.Add(new CartViewModel()
                    {
                        bookId = book.Id,
                        bookName = book.Name,
                        bookImage = book.BookImage,
                        price = book.Price,
                        sale = book.Sale,
                        quantity = cart.quantity > book.Available ? book.Available : cart.quantity,
                    });
                    totalPrice += book.Price * (1 - book.Sale) * (cart.quantity > book.Available ? book.Available : cart.quantity);
                }
            });

            return new ApiResult<object>(success: true, messge: "Thanh cong", payload: new { products = cartViews, totalPrice = totalPrice });
        }

        public async Task<ApiResult<bool>> AddOrder(ListCartRequest ListCartRequest, OrderRequest OrderRequest)
        {

            decimal totalPrice = 0;
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            ListCartRequest.CartRequests.ForEach(cart =>
            {
                var book = eShopDbContext.Books.Find(cart.bookId);
                if (book != null)
                {
                    var bookPrice = (book.Price - book.Price * book.Sale) * cart.quantity;
                    totalPrice += bookPrice;
                    orderDetails.Add(new OrderDetail()
                    {
                        BookId = book.Id,
                        Quantity = cart.quantity,
                        TotalPrice = bookPrice,
                    });
                }
            });

            var newOrder = new Order()
            {
                UserId = OrderRequest.UserId,
                Address = OrderRequest.Address,
                TotalPrice = totalPrice,
                OrderDetails = orderDetails,
            };

            eShopDbContext.Orders.Add(newOrder);

            var dbResult = await eShopDbContext.SaveChangesAsync();
            if (dbResult > 0)
            {
                return new ApiResult<bool>(success: true, messge: "Da dat hang thanh cong", payload: true);
            }
            return new ApiResult<bool>(success: false, messge: "Dat hang khong thanh cong", payload: false);

        }

        public async Task<ApiResult<List<OrderViewModel>>> GetAllOrders()
        {
            var data = from orders in eShopDbContext.Orders
                       select orders;
            if (data.Count() == 0)
                return new ApiResult<List<OrderViewModel>>(success: false, messge: "Khong co don hang nao", payload: null);

            var result = await data.OrderByDescending(x => x.Id).Select(order => new OrderViewModel()
            {
                id = order.Id,
                address = order.Address,
                email = order.User.Email,
                sdt = order.User.PhoneNumber,
                dateCreate = order.DateCreate,
                dateReceive = order.DateReceive,
                totalPrice = order.TotalPrice,
                orderStatus = order.OrderStatus,
                fullName = order.User.FullName,
                userId = order.UserId,
                userName = order.User.FullName,
            }).ToListAsync();

            return new ApiResult<List<OrderViewModel>>(success: true, messge: "Thanh cong", payload: result);

        }

        public async Task<ApiResult<List<OrderDetailViewModel>>> GetGetOrderDetail(int OrderId)
        {
            var data = await eShopDbContext.OrderDetails.Where(x => x.OrderId == OrderId).Select(x => new OrderDetailViewModel()
            {
                OrderId = x.OrderId,
                BookImageUrl = x.Book.BookImage,
                BookId = x.BookId,
                BookName = x.Book.Name,
                Quantity = x.Quantity,
                TotalPrice = x.TotalPrice,
            }).ToListAsync();

            if (data.Count() == 0)
                return new ApiResult<List<OrderDetailViewModel>>(success: false, messge: "Khong tim thay don hang", payload: null);

            return new ApiResult<List<OrderDetailViewModel>>(success: true, messge: "Thanh cong", payload: data);
        }

        public Task<ApiResult<List<OrderViewModel>>> GetOrdersUser(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<bool>> UpdateOrder(int OrderId, OrderRequest OrderRequest)
        {
            var order = eShopDbContext.Orders.Find(OrderId);
            if(order == null)
                return new ApiResult<bool>(success: false, messge: "Khong tim thay don hang", payload: false);


            order.DateReceive = OrderRequest.DateReceive ?? order.DateReceive;
            order.Address = OrderRequest.Address ?? order.Address;
            if(OrderRequest.OrderStatus != DataLayer.Enums.OrderStatus.DA_DAT_HANG)
                order.OrderStatus = OrderRequest.OrderStatus;

            var result = await eShopDbContext.SaveChangesAsync();

            if (result > 0)
                return new ApiResult<bool>(success: true, messge: "Thanh cong", payload: true);
            return new ApiResult<bool>(success: false, messge: "Khong cap nhat", payload: false);

        }

        public Task<ApiResult<bool>> DeleteOrder(Guid UserId, int OrderId)
        {
            throw new NotImplementedException();
        }
    }
}
