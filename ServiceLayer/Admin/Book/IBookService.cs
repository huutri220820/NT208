using ModelAndRequest.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Admin.Product
{
    public interface IBookService
    {
        Task<List<BookViewModel>> GetAllBook(int? categoryId = null);
        BookDetailViewModel GetBookById(int id);
        // return id product
        int AddBook(BookRequest productRequest);
        bool EditBook(BookRequest productRequest);
        bool DeleteBook(int id);
    }
}
