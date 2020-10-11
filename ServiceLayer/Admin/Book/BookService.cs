using DataLayer.EF;
using Microsoft.EntityFrameworkCore;
using ModelAndRequest.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceLayer.Admin.Product
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

        public async Task<List<BookViewModel>> GetAllBook()
        {
            var data = from b in eShopDb.Books
                       join c in eShopDb.Categories on b.CategoryId equals c.Id
                       select new { book = b, category = c.Name};

            var result = await data?.Select(x => new BookViewModel()
            {
                Id = x.book.Id,
                Image = x.book.BookImage,
                Name = x.category,
                Category = x.category,
                Available = x.book.Available,
            }).ToListAsync();

            return result;
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
                Id = data.book.Id,
                Name = data.book.Name,
                CategoryId = data.book.CategoryId,
                Category = data.category,
                Description = data.book.Description,
                Image = data.book.BookImage,
                Available = data.book.Available
            };

            return result;
        }

        
    }
}
