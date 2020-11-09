using DataLayer.EF;
using DataLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModelAndRequest.API;
using ModelAndRequest.Book;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;


namespace ServiceLayer.BookServices
{
    public class BookService : IBookService
    {
        private readonly EShopDbContext eShopDb;
        private readonly IWebHostEnvironment env;
        private IConfiguration configuration;
        public BookService(EShopDbContext eShopDb, IWebHostEnvironment env, IConfiguration configuration)
        {
            this.eShopDb = eShopDb;
            this.env = env;
            this.configuration = configuration;
        }

        public async Task<ApiResult<bool>> AddBook(BookRequest bookRequest)
        {
            if (bookRequest.image == null)
                return new ApiResult<bool>(false, "Khong tim thay anh", false);

            var extension =  Path.GetExtension(bookRequest.image.FileName);
            if (extension != ".jpg" && extension != ".png" )
                return new ApiResult<bool>(false, "vui long chon anh co dinh dang jpg hoac png", false);

            var webRootPath = env.WebRootPath;
            var fileName = "Book" + Guid.NewGuid().ToString() + bookRequest.image.FileName;
            var filePath = Path.Combine(webRootPath, "BookImages", fileName );
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                bookRequest.image.CopyTo(fileStream);
            }
            var book = new Book
            {
                Name = bookRequest.name,
                CategoryId = bookRequest.categoryId,
                Available = bookRequest.available,
                Description = bookRequest.descripton,
                KeyWord = bookRequest.keyWord,
                Price = bookRequest.price,
                Sale = bookRequest.sale,
                BookImage = "BookImages/" + fileName,
            };
            eShopDb.Books.Add(book);
            await eShopDb.SaveChangesAsync();
            return new ApiResult<bool>(true, "Them thanh cong", true);
        }

        public async Task<ApiResult<bool>> DeleteBook(int id)
        {
            var book = await eShopDb.Books.FindAsync(id);
            if (book == null)
                return new ApiResult<bool>(false, $"Khong tim thay sach co id : {id}", false);

            eShopDb.Books.Remove(book);
            var result = await eShopDb.SaveChangesAsync();
            if(result < 1) 
                return new ApiResult<bool>(false, "Xoa khong thanh cong", false);

            return new ApiResult<bool>(true, "Thanh cong", true);
        }

        public bool EditBook(BookRequest bookRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<object>> GetAll()
        {
            var data = from book in eShopDb.Books
                       join category in eShopDb.Categories on book.CategoryId equals category.Id
                       select new { book, category = category.Name };

            if (data == null)
                return new ApiResult<object>(success: false, messge: "Khong tim thay sach", payload: null);

            int total = data.Count();

            var baseUrl = configuration.GetSection("baseUrl").Value;

            var books = await data.Select(x => new BookViewModel()
            {
                id = x.book.Id,
                category = x.category,
                available = x.book.Available,
                image = x.book.BookImage.Contains("http") ? x.book.BookImage : baseUrl + x.book.BookImage,
                name = x.book.Name,
                price = x.book.Price,
                sale = x.book.Sale,
            }).ToListAsync();

            return new ApiResult<object>(success: true, messge: "Thanh cong", payload: new { total, books });

        }

        /// note : them keyword cho book
        public async Task<ApiResult<object>> GetBook(int page = 1, int size = 10, string orderBy = "Price", bool dsc = false, int? categoryId = null, string search = null)
        {
            var data = from book in eShopDb.Books
                       join category in eShopDb.Categories on book.CategoryId equals category.Id
                       select new { book, category = category.Name };
            if (data == null || data.Count() == 0)
                return new ApiResult<object>(success: false, messge: "Khong tim thay sach", payload: null);

            if (categoryId != null)
                data = data.Where(x => x.book.CategoryId == categoryId);
            if (data == null || data.Count() == 0)
                return new ApiResult<object>(success: false, messge: "Khong tim thay sach trong danh muc nay", payload: null);

            if (search != null)
            {
                var searchKey = search.ToUpper();

                data = data.Where(x => x.category.ToUpper().Contains(searchKey) ||
                                    x.book.Category.KeyWord.ToUpper().Contains(searchKey) ||
                                    x.book.Name.ToUpper().Contains(searchKey) ||
                                    x.book.Description.Contains(search) ||
                                    x.book.KeyWord.ToUpper().Contains(searchKey));
            }
            if (data == null || data.Count() == 0)
                return new ApiResult<object>(success: false, messge: $"Khong tim thay sach phu hop voi tu khoa {search}", payload: null);

            int totalPage = (int)Math.Ceiling((decimal)data.Count() / size);
            data = data.AsQueryable().OrderBy($"book.{orderBy} {(dsc ? "descending" : "")}").Skip((page - 1) * size).Take(size);

            var baseUrl = configuration.GetSection("baseUrl").Value;

            var books = await data.Select(x => new BookViewModel()
            {
                id = x.book.Id,
                category = x.category,
                available = x.book.Available,
                image = x.book.BookImage.Contains("http") ? x.book.BookImage : baseUrl + x.book.BookImage,
                name = x.book.Name,
                price = x.book.Price,
                sale = x.book.Sale
            }).ToListAsync();

            return new ApiResult<object>(success: true, messge: $"Thanh cong! Tim thay {data.Count()} cuon sach", payload: new { totalPage, books });
        }

        public async Task<ApiResult<object>> GetBookById(int id)
        {
            var book = await eShopDb.Books.FindAsync(id);
            if (book == null)
                return new ApiResult<object>(success: false, messge: "Khong tim thay sach", payload: null);

            var baseUrl = configuration.GetSection("baseUrl").Value;

            var result = new BookDetailViewModel()
            {
                id = book.Id,
                name = book.Name,
                categoryId = book.CategoryId,
                category = book.Category.Name,
                available = book.Available,
                price = book.Price,
                sale = book.Sale,
                image = book.BookImage.Contains("http") ? book.BookImage : baseUrl + book.BookImage,
                description = book.Description,
                keyWord = book.KeyWord
            };

            return new ApiResult<object>(success: true, messge: "Thanh cong", payload: new { book = result });
        }
    }
}
