//Vo Huu Tri - 18521531 UIT
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
            var result = await eShopDbContext.SaveChangesAsync();

            if (result > 0)
                return new ApiResult<bool>(success: true, messge: "Xoa thanh cong", payload: false);
            return new ApiResult<bool>(success: false, messge: "Xoa Khong thanh cong", payload: true);
        }

        public async Task<ApiResult<bool>> Delete(Guid userId, int bookId)
        {
            var temp = eShopDbContext.CartItems.Find(userId, bookId);
            if (temp == null)
                return new ApiResult<bool>(success: false, messge: "Khong tim thay", payload: false);

            eShopDbContext.CartItems.Remove(temp);

            var result = await eShopDbContext.SaveChangesAsync();
            if (result > 0)
                return new ApiResult<bool>(success: true, messge: "Xoa thanh cong", payload: false);
            return new ApiResult<bool>(success: false, messge: "Xoa Khong thanh cong", payload: true);
        }

        public ApiResult<List<CartViewModel>> Get(Guid userId)
        {
            var data = from user in eShopDbContext.Users
                       join cart in eShopDbContext.CartItems on user.Id equals cart.UserId
                       join book in eShopDbContext.Books on cart.BookId equals book.Id
                       select new { user = user, book = book, quantity = cart.Quantity };

            var result = data?.Select(x =>
                new CartViewModel()
                {
                    bookId = x.book.Id,
                    bookName = x.book.Name,
                    price = x.book.Price,
                    sale = x.book.Sale,
                    bookImage = x.book.BookImage,
                    quantity = x.quantity
                }

            ).ToList();

            if (result != null)
                return new ApiResult<List<CartViewModel>>(success: true, messge: "Thanh cong", payload: result);

            return new ApiResult<List<CartViewModel>>(success: false, messge: "Khong co du lieu tra ve", payload: null);
        }

        public async Task<ApiResult<List<CartViewModel>>> Post(Guid userId, ListCartRequest listCart, bool isReduce)
        {
            listCart?.CartRequests.ForEach(x =>
            {
                var temp = eShopDbContext.CartItems.Find(userId, x.bookId);
                var book = eShopDbContext.Books.Find(x.bookId);

                if (temp != null)
                {
                    if (isReduce)
                    {
                        if (x.quantity == 0)
                            eShopDbContext.CartItems.Remove(temp);
                        else
                            temp.Quantity = x.quantity > book.Available ? book.Available : x.quantity;
                    }
                    else
                    {
                        if (book.Available > 0)
                            temp.Quantity = temp.Quantity + x.quantity > book.Available ? book.Available : temp.Quantity + x.quantity;
                    }
                }
                else
                {
                    if (book.Available > 0)
                    {
                        eShopDbContext.CartItems.AddAsync(new CartItem()
                        {
                            UserId = userId,
                            BookId = x.bookId,
                            Quantity = x.quantity > book.Available ? book.Available : book.Id,
                        });
                    }
                }
            });

            var db = await eShopDbContext.SaveChangesAsync();
            var data = from user in eShopDbContext.Users
                       join cart in eShopDbContext.CartItems on user.Id equals cart.UserId
                       join book in eShopDbContext.Books on cart.BookId equals book.Id
                       select new { user = user, book = book, quantity = cart.Quantity };

            var result = data?.Select(x =>
                new CartViewModel()
                {
                    bookId = x.book.Id,
                    bookName = x.book.Name,
                    price = x.book.Price,
                    sale = x.book.Sale,
                    bookImage = x.book.BookImage,
                    quantity = x.quantity
                }

            ).ToList();

            if (result != null)
                return new ApiResult<List<CartViewModel>>(success: true, messge: "Thanh cong", payload: result);
            return new ApiResult<List<CartViewModel>>(success: false, messge: "Khong co du lieu tra ve", payload: null);
        }
    }
}