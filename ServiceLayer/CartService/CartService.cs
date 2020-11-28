using DataLayer.EF;
using DataLayer.Entities;
using ModelAndRequest.API;
using ModelAndRequest.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.CartService
{
    public class CartService : ICartService
    {
        private readonly EShopDbContext eShopDbContext;

        public CartService(EShopDbContext eShopDbContext)
        {
            this.eShopDbContext = eShopDbContext;
        }

        public async Task<ApiResult<bool>> Clear(Guid userId)
        {
            eShopDbContext.Users.Find(userId)?.CartItems.Clear();
            var result =  await eShopDbContext.SaveChangesAsync();

            if(result > 0)
                return new ApiResult<bool>(success: true, messge: "Xoa thanh cong", payload: false);
            return new ApiResult<bool>(success: false, messge: "Xoa Khong thanh cong", payload: true);
        }

        public async Task<ApiResult<bool>> Delete(Guid userId, int bookId)
        {
            var temp = eShopDbContext.CartItems.Find(userId, bookId);
            if(temp == null)
                return new ApiResult<bool>(success: false, messge: "Khong tim thay", payload: false);

            eShopDbContext.CartItems.Remove(temp);

            var result = await eShopDbContext.SaveChangesAsync();
            if (result > 0)
                return new ApiResult<bool>(success: true, messge: "Xoa thanh cong", payload: false);
            return new ApiResult<bool>(success: false, messge: "Xoa Khong thanh cong", payload: true);
        }

        public async Task<ApiResult<List<CartViewModel>>> Sync(Guid userId, ListCartRequest listCart, bool isReduce)
        {

            listCart?.CartRequests.ForEach(x =>
            {

                var temp = eShopDbContext.CartItems.Find(userId, x.bookId);
                if (temp != null)
                    temp.Quantity = !isReduce ? temp.Quantity + x.quantity : x.quantity;
                else
                    eShopDbContext.CartItems.AddAsync(new CartItem()
                    {
                        UserId = userId,
                        BookId = x.bookId,
                        Quantity = x.quantity
                    });
            });

            var db = await eShopDbContext.SaveChangesAsync();
            if (db > 0)
            {
                var data = from user in eShopDbContext.Users
                           join cart in eShopDbContext.CartItems on user.Id equals cart.UserId
                           join book in eShopDbContext.Books on cart.BookId equals book.Id
                           select new { user = user, book = book, quantity = cart.Quantity };

                var result = data?.Select(x =>
                    new CartViewModel()
                    {
                        userId = x.user.Id,
                        bookId = x.book.Id,
                        bookName = x.book.Name,
                        price = x.book.Price,
                        bookImage = x.book.BookImage,
                        quantity = x.quantity
                    }

                ).ToList();

                if (result != null)
                    return new ApiResult<List<CartViewModel>>(success: true, messge: "Thanh cong", payload: result);

                return new ApiResult<List<CartViewModel>>(success: false, messge: "Khong co du lieu tra ve", payload: null);
            }
            return new ApiResult<List<CartViewModel>>(success: false, messge: "Dong bo that bai", payload: null);
        }

    }

}
