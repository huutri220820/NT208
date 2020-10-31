using DataLayer.EF;
using Microsoft.EntityFrameworkCore;
using ModelAndRequest.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceLayer.Book
{
    public class BookService : IBookService
    {
        private readonly EShopDbContext eShopDb;
        public BookService(EShopDbContext eShopDb)
        {
            this.eShopDb = eShopDb;
        }

        public int AddBook(BookRequest productRequest)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditBook(BookRequest productRequest)
        {
            throw new NotImplementedException();
        }



        public async Task<(List<BookViewModel> bookListView, int total)> GetAllBook(int? categoryId = null, string search = null, int? page = null, int count = 10)
        {
            var data = from b in eShopDb.Books
                       where categoryId == null || b.CategoryId == categoryId
                       join c in eShopDb.Categories on b.CategoryId equals c.Id
                       select new { book = b, category = c.Name };

            var total = data.Count();

            var result = await data?.Select(x => new BookViewModel()
            {
                id = x.book.Id,
                name = x.book.Name,
                category = x.category,
                available = x.book.Available,
                image = x.book.BookImage,
            }).ToListAsync();

            return (bookListView: result, total);
        }

        public BookDetailViewModel GetBookById(int id)
        {
            var data = (from b in eShopDb.Books
                        join c in eShopDb.Categories on b.CategoryId equals c.Id
                        where b.Id == id
                        select new { book = b, category = c.Name }).FirstOrDefault();

            if (data == null)
                return null;

            var result = new BookDetailViewModel()
            {
                id = data.book.Id,
                name = data.book.Name,
                categoryId = data.book.CategoryId,
                category = data.category,
                description = data.book.Description,
                available = data.book.Available,
                image = data.book.BookImage
            };

            return result;
        }


    }
}
