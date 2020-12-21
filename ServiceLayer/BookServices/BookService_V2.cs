//Vo Huu Tri - 18521531 UIT
using DataLayer.EF;
using DataLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModelAndRequest.API;
using ModelAndRequest.Book;
using ModelAndRequest.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace ServiceLayer.BookServices
{
    public class BookService_V2 : IBookService
    {
        private readonly EShopDbContext eShopDb;
        private readonly IWebHostEnvironment env;
        private IConfiguration configuration;

        public BookService_V2(EShopDbContext eShopDb, IWebHostEnvironment env, IConfiguration configuration)
        {
            this.eShopDb = eShopDb;
            this.env = env;
            this.configuration = configuration;
        }

        public async Task<ApiResult<bool>> AddBook(BookRequest bookRequest)
        {
            if (String.IsNullOrEmpty(bookRequest.imageBase64))
                return new ApiResult<bool>(false, "Khong tim thay anh", false);

            var book = new Book
            {
                Name = bookRequest.name,
                Author = bookRequest.author,
                CategoryId = bookRequest.categoryId,
                Available = bookRequest.available,
                Description = bookRequest.descripton,
                KeyWord = bookRequest.keyword,
                Price = bookRequest.price,
                Sale = bookRequest.sale ?? 0,
                BookImage = bookRequest.imageBase64,
            };

            eShopDb.Books.Add(book);
            var result = await eShopDb.SaveChangesAsync();

            if (result > 0)
                return new ApiResult<bool>(true, "Them thanh cong", true);
            return new ApiResult<bool>(false, "Khong thanh cong", false);
        }

        public async Task<ApiResult<bool>> DeleteBook(int id)
        {
            var book = await eShopDb.Books.FindAsync(id);
            if (book == null)
                return new ApiResult<bool>(false, $"Không tìm thấy cuốn sách có id : {id}", false);

            book.isDelete = true;
            var result = await eShopDb.SaveChangesAsync();
            if (result < 1)
                return new ApiResult<bool>(false, "Xóa không thành công", false);

            return new ApiResult<bool>(true, "Xóa thành công", true);
        }

        public async Task<ApiResult<bool>> EditBook(int id, BookRequest bookRequest)
        {
            var book = await eShopDb.Books.FindAsync(id);

            if (book == null)
                return new ApiResult<bool>(false, $"Không tìm thấy cuốn sách có id : {id}", false);

            book.Name = bookRequest.name;
            book.Author = bookRequest.author;
            book.Available = bookRequest.available;
            book.Description = bookRequest.descripton;
            book.CategoryId = bookRequest.categoryId;
            book.Description = bookRequest.descripton;
            book.Price = bookRequest.price;
            book.Sale = bookRequest.sale ?? 0;

            if (!String.IsNullOrEmpty(bookRequest.imageBase64))
                book.BookImage = bookRequest.imageBase64;

            var result = await eShopDb.SaveChangesAsync();
            if (result > 0)
                return new ApiResult<bool>(true, "Thành công", true);
            return new ApiResult<bool>(false, "Không Thành công", false);
        }

        public async Task<ApiResult<object>> GetAll()
        {
            var data = from book in eShopDb.Books
                       join category in eShopDb.Categories on book.CategoryId equals category.Id
                       where book.isDelete == false
                       select new { book, category = category.Name };

            if (data == null)
                return new ApiResult<object>(success: false, messge: "Không tìm thấy sách", payload: null);

            int total = data.Count();

            var books = await data.Select(x => new BookViewModel()
            {
                id = x.book.Id,
                author = x.book.Author,
                category = x.category,
                available = x.book.Available,
                image = x.book.BookImage,
                name = x.book.Name,
                price = x.book.Price,
                star = x.book.BookRatings.Sum(x => x.Rating),
                rating_count = x.book.BookRatings.Count(),
                sale = x.book.Sale,
            }).ToListAsync();

            return new ApiResult<object>(success: true, messge: "Thành công", payload: new { total, books });
        }

        public async Task<ApiResult<object>> GetBook(int page = 1, int size = 10, string orderBy = "Price", bool dsc = false, int? categoryId = null, string search = null, bool? isSuspend = null)
        {
            var data = eShopDb.Books.Include(x => x.Category).Include(x => x.BookRatings).Where(x => x.isDelete == false);

            if (data == null || data.Count() == 0)
                return new ApiResult<object>(success: false, messge: "Không tìm thấy sách", payload: null);

            if (isSuspend != null)
                data = isSuspend == true ? data.Where(x => x.Available <= 0) : data.Where(x => x.Available > 0);

            if (categoryId != null)
            {
                data = data.Where(x => x.CategoryId == categoryId);
                if (data == null || data.Count() == 0)
                    return new ApiResult<object>(success: false, messge: "Không tìm thấy sách trong danh mục này", payload: null);
            }

            if (search != null)
            {
                var searchKey = search.ToUpper();

                data = data.Where(x => x.Category.Name.ToUpper().Contains(searchKey) ||
                                    x.Category.KeyWord.ToUpper().Contains(searchKey) ||
                                    x.Name.ToUpper().Contains(searchKey) ||
                                    //x.book.Description.Contains(search) ||
                                    x.KeyWord.ToUpper().Contains(searchKey) || x.Author.ToUpper().Contains(searchKey));

                if (data == null || data.Count() == 0)
                    return new ApiResult<object>(success: false, messge: $"Không tồn tại sách chứa từ khóa {search}", payload: null);
            }

            int totalPage = (int)Math.Ceiling((decimal)data.Count() / size);
            //data = data.AsQueryable().OrderBy($"book.{orderBy} {(dsc ? "descending" : "")}").Skip((page - 1) * size).Take(size);
            data = data.AsQueryable().OrderBy($"{orderBy} {(dsc ? "descending" : "")}").Skip((page - 1) * size).Take(size);

            //var ab = data.Where(x=>x.book.Id == 4).First().book.BookRatings.Count();
            //var ac = data.Where(x=>x.book.Id == 4).First().book.BookRatings.Sum(x=>x.Rating);

            var books = await data.Select(x => new BookViewModel()
            {
                id = x.Id,
                category = x.Category.Name,
                author = x.Author,
                available = x.Available,
                image = x.BookImage,
                name = x.Name,
                star = x.BookRatings.Sum(x => x.Rating),
                rating_count = x.BookRatings.Count(),
                price = x.Price,
                sale = x.Sale
            }).ToListAsync();

            return new ApiResult<object>(success: true, messge: $"Thành công! Tìm thấy {data.Count()} sách", payload: new { totalPage, books });
        }

        public async Task<ApiResult<object>> GetBookById(int id)
        {
            var book = await eShopDb.Books.FindAsync(id);

            if (book == null)
                return new ApiResult<object>(success: false, messge: "Không tìm thấy sách", payload: null);

            if (book.isDelete == true)
                return new ApiResult<object>(success: false, messge: "Sách đã bị xóa", payload: null);

            var result = new BookDetailViewModel()
            {
                id = book.Id,
                name = book.Name,
                author = book.Author,
                categoryId = book.CategoryId,
                category = book.Category.Name,
                available = book.Available,
                price = book.Price,
                sale = book.Sale,
                image = book.BookImage,
                description = book.Description,
                keyWord = book.KeyWord,

                comments = book.BookRatings.Select(x => new RatingViewModel()
                {
                    id = x.Id,
                    userId = x.UserId,
                    username = x.User.FullName,
                    comment = x.Comment,
                    rating = x.Rating,
                    avatar = x.User.Avatar,
                }).ToList(),
            };

            return new ApiResult<object>(success: true, messge: "Thành công", payload: new { book = result });
        }

        public bool TestImage(IFormFile image)
        {
            throw new NotImplementedException();
        }
    }
}