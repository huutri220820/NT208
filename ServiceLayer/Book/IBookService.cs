using ModelAndRequest.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Book
{
    public interface IBookService
    {
        Task<(List<BookViewModel> bookListView, int total)> GetAllBook(int? categoryId = null, string search = null, int? page = null, int count = 10);
        BookDetailViewModel GetBookById(int id);
        // return id product
        int AddBook(BookRequest productRequest);
        bool EditBook(BookRequest productRequest);
        bool DeleteBook(int id);
    }
}
