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
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
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

            var extension = Path.GetExtension(bookRequest.image.FileName);
            if (extension != ".jpg" && extension != ".png")
                return new ApiResult<bool>(false, "vui long chon anh co dinh dang jpg hoac png", false);

            var webRootPath = env.WebRootPath;
            var fileName = "Book" + Guid.NewGuid().ToString() + bookRequest.image.FileName;
            var filePath = Path.Combine(webRootPath, "BookImages", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                bookRequest.image.CopyTo(fileStream);
            }
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

            if (bookRequest.image != null)
            {
                var extension = Path.GetExtension(bookRequest.image.FileName);
                if (extension == ".jpg" || extension == ".png")
                {
                    var webRootPath = env.WebRootPath;
                    var fileName = book.BookImage;
                    var filePath = Path.Combine(webRootPath, fileName);
                    try
                    {
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            bookRequest.image.CopyTo(fileStream);
                        }
                    }
                    catch
                    {
                        return new ApiResult<bool>(false, "Không thành công", false);
                    }
                }
                else
                    return new ApiResult<bool>(false, "vui long chon anh co dinh dang jpg hoac png", false);
            }

            await eShopDb.SaveChangesAsync();
            return new ApiResult<bool>(true, "Thành công", true);
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

            var baseUrl = configuration.GetSection("baseUrl").Value;

            var books = await data.Select(x => new BookViewModel()
            {
                id = x.book.Id,
                author = x.book.Author,
                category = x.category,
                available = x.book.Available,
                image = x.book.BookImage.Contains("http") ? x.book.BookImage : baseUrl + x.book.BookImage,
                name = x.book.Name,
                price = x.book.Price,
                sale = x.book.Sale,
            }).ToListAsync();

            return new ApiResult<object>(success: true, messge: "Thành công", payload: new { total, books });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="page">trang can lay</param>
        /// <param name="size">so luong tren moi trang</param>
        /// <param name="orderBy">sap xep theo xxx vd: name</param>
        /// <param name="dsc">giam dan = true</param>
        /// <param name="categoryId">danh muc</param>
        /// <param name="search">tu khoa tim kiem</param>
        /// <param name="isSuspend">het hang hay con hang</param>
        /// <returns></returns>
        public async Task<ApiResult<object>> GetBook(int page = 1, int size = 10, string orderBy = "Price", bool dsc = false, int? categoryId = null, string search = null, bool? isSuspend = null)
        {
            var data = from book in eShopDb.Books
                       join category in eShopDb.Categories on book.CategoryId equals category.Id
                       where book.isDelete == false
                       select new { book, category = category.Name };

            if (data == null || data.Count() == 0)
                return new ApiResult<object>(success: false, messge: "Không tìm thấy sách", payload: null);

            if (isSuspend != null)
                data = isSuspend == true ? data.Where(x => x.book.Available <= 0) : data.Where(x => x.book.Available > 0);

            if (categoryId != null)
            {
                data = data.Where(x => x.book.CategoryId == categoryId);
                if (data == null || data.Count() == 0)
                    return new ApiResult<object>(success: false, messge: "Không tìm thấy sách trong danh mục này", payload: null);
            }

            if (search != null)
            {
                var searchKey = search.ToUpper();

                data = data.Where(x => x.category.ToUpper().Contains(searchKey) ||
                                    x.book.Category.KeyWord.ToUpper().Contains(searchKey) ||
                                    x.book.Name.ToUpper().Contains(searchKey) ||
                                    //x.book.Description.Contains(search) ||
                                    x.book.KeyWord.ToUpper().Contains(searchKey));

                if (data == null || data.Count() == 0)
                    return new ApiResult<object>(success: false, messge: $"Không tồn tại sách chứa từ khóa {search}", payload: null);
            }

            int totalPage = (int)Math.Ceiling((float)data.Count() / size);
            data = data.AsQueryable().OrderBy($"book.{orderBy} {(dsc ? "descending" : "")}").Skip((page - 1) * size).Take(size);

            var baseUrl = configuration.GetSection("baseUrl").Value;

            var books = await data.Select(x => new BookViewModel()
            {
                id = x.book.Id,
                category = x.category,
                author = x.book.Author,
                available = x.book.Available,
                image = x.book.BookImage.Contains("http") ? x.book.BookImage : baseUrl + x.book.BookImage,
                name = x.book.Name,
                price = x.book.Price,
                sale = x.book.Sale
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

            var baseUrl = configuration.GetSection("baseUrl").Value;

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
                //kiểm tra hình ảnh là link hay url
                image = book.BookImage.Contains("http") ? book.BookImage : baseUrl + book.BookImage,
                description = book.Description,
                keyWord = book.KeyWord,
                comments = book.BookRatings.Select(x => new RatingViewModel()
                {
                    id = x.Id,
                    userId = x.UserId,
                    username = x.User.FullName,
                    comment = x.Comment,
                    rating = x.Rating,
                    avatar = x.User.Avatar.Contains("http") ? x.User.Avatar : baseUrl + x.User.Avatar
                }).ToList<RatingViewModel>(),
            };

            return new ApiResult<object>(success: true, messge: "Thành công", payload: new { book = result });
        }

        public bool TestImage(IFormFile image)
        {
            if (image != null)
            {
                var extension = Path.GetExtension(image.FileName);
                if (extension == ".jpg" || extension == ".png")
                {
                    var webRootPath = env.WebRootPath;
                    var fileName = image.FileName;
                    var filePath = Path.Combine(webRootPath, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }
                }
            }
            return false;
        }
    }
}